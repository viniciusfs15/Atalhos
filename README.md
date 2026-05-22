# Atalhos

## 📋 Objetivo do Projeto

O **Atalhos** é uma aplicação desktop desenvolvida para auxiliar desenvolvedores na inicialização e gerenciamento do serviço de Host e aplicação RM.exe do ERP TOTVS RM. A ferramenta oferece uma interface intuitiva para facilitar o acesso rápido aos ambientes e atalhos configurados, economizando tempo em tarefas repetitivas.

---

## 🚀 Instalando o Atalhos

Para instalar o Atalhos, siga estas etapas:

### Windows

1. Baixe o arquivo `Atalhos.zip` do [repositório oficial](https://github.com/viniciusfs15/Atalhos);
2. Extraia os arquivos para uma pasta de sua preferência;
3. Execute o arquivo `Atalhos.exe`.

**Requisitos:**
- Windows 10 ou superior
- .NET 8.0 Runtime (será necessário para executar a aplicação)

---

## ☕ Usando o Atalhos

### Interface Principal

Após executar o `Atalhos.exe`, você será apresentado à interface principal da aplicação.

**[ADICIONAR PRINT DA TELA PRINCIPAL AQUI]**

A tela principal oferece acesso rápido aos seguintes funcionalidades:
- Listar ambientes configurados
- Iniciar Host e RM.exe
- Acessar atalhos personalizados
- Gerenciar configurações de ambientes

---

### Form: Tela Principal

A tela principal é o coração da aplicação. Nela você pode:

- **Selecionar um Ambiente:** Escolha entre os ambientes para trabalhar
- **Favorito**: Marque um ambiente como favorito para acesso rápido sempre que iniciar a aplicação
- **Auto Login:** Habilite o auto-login para acessar o ambiente selecionado sem precisar inserir credenciais manualmente
- **Selecionar um Alias:** Inicie o ambiente selecionado com um alias específico
- **Controla IIS**: Habilite para que ao utilizar o botão **Reiniciar IIS** os aplicativos FrameHTML e Corpore.Net no IIS sejam configurados no caminho correto do ambiente selecionado
- **Iniciar Host ou RM.exe:** Com um clique, inicie os serviços necessários para o ambiente selecionado
- **Acessar Atalhos:** Visualize e execute atalhos rápidos disponíveis para o ambiente como abrir pastas, ferramentas auxiliares, IIS,etc.
- **Minimizar para a bandeja do Windows:** Mantenha a aplicação sempre acessível sem ocupar espaço na barra de tarefas

**[ADICIONAR PRINT DA INTERFACE PRINCIPAL AQUI]**

#### Funcionalidades principais:
- Interface amigável com tema Material Design
- Integração com a bandeja do sistema (system tray)
- Gerenciamento de ambientes e atalhos
- Feedback visual de operações em andamento

---

### 🗂️ Minimizar para Bandeja do Sistema (Tray)

O Atalhos oferece a funcionalidade de minimizar a aplicação para a bandeja do sistema do Windows, permitindo que você mantenha a ferramenta sempre acessível sem ocupar espaço na barra de tarefas.

**[ADICIONAR PRINT DO TRAY COM MENUS AQUI]**

#### Como usar:

1. **Minimizar para Tray:**
   - Marque o CheckBox "Minimizar para a bandeja do Windows" na tela principal
   - A partir disso, ao minimizar ou fechar a janela principal, a aplicação será reduzida para a bandeja do sistema em vez de ser encerrada   

2. **Acessar a Aplicação:**
   - Procure pelo ícone do Atalhos na bandeja do sistema (canto inferior direito da tela, próximo ao relógio)
   - Clique no ícone para restaurar a janela principal

3. **Menu de Contexto do Tray:**
   - Clique com o botão direito no ícone do Atalhos na bandeja para acessar um menu rápido com:
     - **Ambientes:** Acesso rápido aos atalhos de cada ambiente configurando, podendo selecionar qual Alias será executado
     - **Encerrar RM.exe e Hosts:** Encerrar todos os processos do RM
     - **Encerrar RM.exe:** Encerrar apenas os processos do RM.exe
     - **Encerrar Host:** Ecerrar apenas os processos do Host
     - **Abrir IIS:** Abre o Gerenciador do IIS
     - **Abrir janela principal:** Abre a janela principal da aplicação
     - **Sair:** Encerra a aplicação completamente

#### Benefícios:
- Mantenha a aplicação sempre disponível sem distrações
- Acesso rápido aos ambientes e atalhos diretamente da bandeja
- Interface limpa e organizada na barra de tarefas
- Reduz o uso de espaço na área de trabalho

---

### Form: Editor de Ambientes

O Editor de Ambientes permite configurar os detalhes de cada ambiente de trabalho.

**[ADICIONAR PRINT DO FORM DE EDIÇÃO DE AMBIENTES AQUI]**

#### Como usar:

1. Na tela principal, selecione um ambiente
2. Clique no botão de engragem ao lado do ComboBox de Ambientes para abrir o formulário
3. Configure os seguintes campos:
   - **Host:** Nome do Host do ambiente
   - **Port:** Porta de comunicação do Host
   - **HttpPort:** Porta HTTP do ambiente
   - **ApiPort:** Porta da API do ambiente
   - **EnableCompression:** Habilitar compressão para comunicação com o Host
   - **Job Server 3 Camadas:** Habilitar a opção de N Camadas para o ambiente
   - **Desativa JobRunner:** Adiciona as Tags EnableProcessIsolation e IsolateProcess para nos arquivos config com o valor "false", desativando o JobRunner e facilitando o debug do serviço de Host
   - **DefaultDB:** Adicione a tag DefaultDB com o valor "CorporeRM" (nome utilizado nos alias do Atalhos para execução da aplicação)

Ainda é possível executar a ação de **Normalizar caminhos dos Configs**. 
Esta ação irá verificar os caminhos dos executáveis do Host e RM.exe, e caso algum deles esteja incorreto ou desatualizado, a aplicação irá configurar o caminho correto com base na estrutura de pastas do ambiente. 
Isso é especialmente útil para garantir que os caminhos estejam sempre atualizados, evitando falhas na execução dos serviços.

4. Clique em **Salvar** para confirmar as alterações

---

### Form: Editor de Alias

O Editor de Alias permite criar atalhos personalizados para executáveis ou caminhos específicos dentro de um ambiente.

**[ADICIONAR PRINT DO FORM DE EDIÇÃO DE ALIAS AQUI]**

#### Como usar:

1. Na tela principal, selecione um ambiente
2. Clique no botão de engrenagem ao lado do ComboBox de Alias para abrir o formulário
3. Na lista de alias:
   - **Novo Alias:** Clique em "Novo" para criar um novo atalho
   - **Nome do Alias:** Nome do alias para identificação no Atalhos
   - **Tipo da base:** Defina a base de dados utilizada para o alias, como SQL Server ou Oracle
   - **Servidor:** Servidor de banco de dados associado ao alias
   - **Base:** Base de dados associada ao alias
   - **Usuário BD:** Usário de banco de dados associado ao alias
   - **Senha BD:** Senha de banco de dados associada ao alias
   - **Usuário RM:** Usuário do RM para o auto-login do ambiente
   - **Senha RM:** Senha do RM para o auto-login do ambiente
   - Entre outras tags personalizadas que podem ser utilizadas para configurar o ambiente de acordo com as necessidades do usuário

4. Clique em **Salvar** para confirmar as alterações

---

## 📫 Contribuindo para Atalhos

Para contribuir com Atalhos, siga estas etapas:

1. **Bifurque este repositório**
   - Clique no botão "Fork" no GitHub

2. **Crie um branch para sua feature**
   ```bash
   git checkout -b <nome_branch>
   ```

3. **Faça suas alterações e confirme-as**
   ```bash
   git commit -m '<mensagem_commit>'
   ```

4. **Envie para o branch original**
   ```bash
   git push origin <nome_do_projeto>/<local>
   ```

5. **Crie a solicitação de pull (Pull Request)**
   - Descreva as mudanças realizadas
   - Referencie issues relacionadas, se aplicável

Para mais informações, consulte a [documentação do GitHub sobre Pull Requests](https://docs.github.com/pt/pull-requests).

---

## 📝 Licença

Este projeto é fornecido como está. Verifique o repositório para mais informações sobre a licença.

---

## 🔗 Links Úteis

- [Repositório GitHub](https://github.com/viniciusfs15/Atalhos)
- [ERP TOTVS RM](https://www.totvs.com.br/erp/rm)

---

## 💬 Dúvidas?

Se tiver dúvidas ou sugestões sobre o Atalhos, abra uma [issue no repositório](https://github.com/viniciusfs15/Atalhos/issues).
