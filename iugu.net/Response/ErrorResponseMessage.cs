using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iugu.net.Response
{
    public class ErrorResponseMessage
    {
        public int StatusCode { get; private set; }
        public string ReasonPhase { get; private set; }
        public List<ErrorMessage> Errors { get; set; }

        private ErrorResponseMessage(int statusCode, string reasonPhase, List<ErrorMessage> errors)
        {
            StatusCode = statusCode;
            ReasonPhase = reasonPhase;
            Errors = errors;
        }

        private ErrorResponseMessage(int statusCode, string reasonPhase, string simpleErrorMessage)
        {
            StatusCode = statusCode;
            ReasonPhase = reasonPhase;
            Errors = new List<ErrorMessage> { new ErrorMessage("Error", new string[] { simpleErrorMessage }) };
        }


        /// <summary>
        /// Método utilizado para serializar a resposta de erro da IUGU
        /// </summary>
        /// <param name="currentErrorMessage">mensagem atual retornada da requisição</param>
        /// <param name="erroMessages">Classe que representa os erros retornados de uma request</param>
        /// <returns></returns>
        [Obsolete("Não será mais necessário na versão 2.x, resolve a issue ref: https://github.com/iugu/iugu-net/issues/54")]
        public static async Task<ErrorResponseMessage> BuildAsync(string currentErrorMessage)
        {
            try
            {
                var jsonMessage = await Task.FromResult(JsonConvert.DeserializeObject<IuguCompleteComplexErrorResponse>(currentErrorMessage))
                                            .ConfigureAwait(false);

                var errors = jsonMessage.Message.Errors.Select(e => new ErrorMessage(e.Key, e.Value.Values<string>().ToArray())).ToList();
                return new ErrorResponseMessage(jsonMessage.StatusCode, jsonMessage.ReasonPhase, errors);
            }
            catch (Exception)
            {
                try
                {
                    var jsonMessage = await Task.FromResult(JsonConvert.DeserializeObject<IuguCompleteSimpleErrorResponse>(currentErrorMessage))
                                                .ConfigureAwait(false);

                    return new ErrorResponseMessage(jsonMessage.StatusCode, jsonMessage.ReasonPhase, jsonMessage.Message);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }

    public class ErrorMessage
    {
        public string FieldName { get; private set; }
        public string[] Errors { get; private set; }

        public ErrorMessage(string fieldName, string[] errors)
        {
            FieldName = fieldName;
            Errors = errors;
        }
    }


    internal sealed class IuguCompleteComplexErrorResponse
    {
        public int StatusCode { get; set; }
        public string ReasonPhase { get; set; }
        public UnformattedErrorMessage Message { get; set; }
    }

    internal sealed class UnformattedErrorMessage
    {
        public Dictionary<string, JArray> Errors { get; set; }
    }

    internal sealed class IuguCompleteSimpleErrorResponse
    {
        public int StatusCode { get; set; }
        public string ReasonPhase { get; set; }
        public string Message { get; set; }
    }

}

