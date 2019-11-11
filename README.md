# iugu.net
Client .Net de acesso aos principais recursos da Api da **IUGU**

 Master Build | Develop Build | Nuget | Master Coverage % | Develop Coverage % |
--------------|---------------|------------|----------- |-----------|
|[![Build status](https://ci.appveyor.com/api/projects/status/aoicbabfky8vtvy3/branch/master?svg=true)](https://ci.appveyor.com/project/rscouto/iugu-net/branch/master) | [![Build status](https://ci.appveyor.com/api/projects/status/aox0w63vmeiapfjy?svg=true)](https://ci.appveyor.com/project/rscouto/iugu-net-fx8qt) | [![NuGet version](https://badge.fury.io/nu/iugu.net.svg)](https://badge.fury.io/nu/iugu.net) | [![Coverage Status](https://coveralls.io/repos/github/iugu/iugu-net/badge.svg?branch=master)](https://coveralls.io/github/iugu/iugu-net?branch=master)|[![Coverage Status](https://coveralls.io/repos/github/iugu/iugu-net/badge.svg?branch=master)](https://coveralls.io/github/iugu/iugu-net?branch=develop)



### Instalação

* No visual Studio > Abrir o **Package Manager Console**

> Install-Package iugu.net

### Configuração

* Em algum *StartUp* de seu projeto, é necessário adicionar a apiKey encontrada no seu painel [administrativo da IUGU](https://iugu.com/a/administration), em *Administração* > *Configuração de Contas*. Nesta tela você encontra seu *ID da Conta* 

```csharp
IuguClient.Init(new IuguClientProperties()
{
    ApiKey = "SUA_APP_KEY_DA_IUGU"
});
```
### Documentação completa da API
A referência completa da Api pode ser encontrada em [IUGU Api](https://iugu.com/referencias/api)

### Exemplo ([outros exemplos](https://github.com/iugu/iugu-net/tree/develop/iugu.net.IntegratedTests))

* Lista Clientes

```csharp
public class AnyClass
{
    public CustomersModel GetAllClient()
    {
        CustomersModel myClients;
        using (var apiClient = new Lib.Customer())
        {
            myClients = await apiClient.GetAsync().ConfigureAwait(false);
        };
        return myClients;
     }
}
```

### Informações Adicionais
* A partir da versão 2.0, o projeto foi reestruturado para ser compilado de forma *retrocompatível* com **.NET Standard 2.0** e **.NET Framework 4.5**.
Essas alterações não provocam nenhuma quebra de versão em atuais projetos **.NET Framework** e consequentemente adiciona suporte nativo ao **.NET Standard 2.0**.

* A partir da versão 2.0, o cliente **NÃO** é mais configurado através de arquivos `.config`, e sim através do factory `IuguClient.Init`, conforme exemplo acima.

* A partir da versão 1.8.5, houve um downgrade da **versão miníma do .Net framework para a versão 4.5** e uma mudança nas dependências.
Essas alterações não provocam necessáriamente quebra de versões, a não ser que exista um conflito de dependências.