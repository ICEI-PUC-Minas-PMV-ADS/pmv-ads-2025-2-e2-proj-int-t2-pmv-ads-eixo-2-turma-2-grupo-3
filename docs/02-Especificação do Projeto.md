# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Perfis de Usuários

### Perfil Médico
**Descrição:**  
Profissional de saúde disposto a atender pacientes vulneráveis  .

**Necessidades:**  
Visualizar e aderir campanhas, visualizar e remarcar agendamentos de consultas médicas .

### Perfil Paciente
**Descrição:**  
Acesso rápido, fácil e gratuito a consultas médicas  .

**Necessidades:**  
Agendamento e cancelamento de consultas gratuitas .

### Perfil Consultório médico
**Descrição:**  
Fazer a conexão entre médico e paciente de forma gratuita, fácil e controlada.

**Necessidades:**  
Criar e gerenciar campanhas, gerenciar médicos voluntários em suas campanhas.

## Histórias de Usuários

| EU COMO... `QUEM`               | QUERO/DESEJO ... `O QUE`                                    | PARA ... `PORQUE`                                                    |
|---------------------------------|-------------------------------------------------------------|-------------------------------------------------------------------|
| Eu como paciente de baixa renda | quero visualizar consultas médicas                          | para obter mais informações em relação a minha consulta              |
| Eu como paciente de baixa renda | quero agendar ou cancelar consultas                         | para ser atendido e sanado meus problemas de saúde                   |
| Eu como consultório médico      | desejo criar, alterar e excluir campanhas de saúde          | para atender a população vulnerável                                  |
| Eu como consultório médico      | quero criar, visualizar, editar e excluir contas de médicos | para gerenciar contas médicas que prestam atendimento                |
| Eu como médico                  | desejo visualizar e cancelar consultas médicas              | para ajudar essas pessoas a terem acesso à saúde básica              |
| Eu como médico                  | quero aderir campanhas de consultas médicas gratuitas       | para disponibilizar do meu tempo para ajudar pacientes necessitados  |



## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01| O paciente deve poder cadastrar, consultar, alterar e excluir seu usuário no sistema | MEDIA | 
|RF-02| O paciente deve poder agendar, consultar e cancelar suas consultas médicas no sistema | ALTA |
|RF-03| O consultório médico deve poder cadastrar, consultar, alterar e excluir seu usuário no sistema | MEDIA |
|RF-04| O consultório médico deve poder cadastrar, consultar, alterar e excluir médicos do sistema | MEDIA |
|RF-05| O consultório médico deve poder cadastrar, consultar, alterar e excluir campanhas do sistema | MEDIA |
|RF-06| O médico voluntário deve poder cadastrar, consultar, alterar e excluir seu usuário no sistema | MEDIA |
|RF-07| O médico voluntário deve poder aderir campanhas, consultar e remarcar consultas médicas no sistema | ALTA |
|RF-08| O sistema deve consultar os CNPJ na base de dados para validação de consultórios médicos no cadastro de usuário | MEDIA |
|RF-09| O sistema deve consultar os CAD únicos na base de dados para validação de pacientes no cadastro de usuário | MEDIA |
|RF-10| O sistema deve consultar os CRM na base de dados para validação de médicos no cadastro de usuário | MEDIA |
|RF-11| O sistema deve filtrar médicos por campanha, especialidade, data e horário no agendamento de consultas | ALTA |
|RF-12| O sistema deve ter autenticação básica (HTTP Basic) | BAIXA |
|RF-13| O sistema deve ter mecanismo de alteração de senha via envio de e-mail | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001|  O sistema deve as senhas de usuários criptografadas em sua base de dados | BAIXA | 
|RNF-002| O sistema deve suportar mil usuários simultâneos |  MEDIA |
|RNF-003| O sistema deve ser de fácil usabilidade e responsiva  |  ALTA  |
|RNF-004|O sistema deverá ter alta disponibilidade em 98% do tempo  |  ALTA |
|RNF-005| O sistema deverá ser escalável  |  BAIXA |
|RNF-006|O sistema deverá executar em duas plataformas: mobile e desktop|  MEDIA |
|RNF-007|O sistema será desenvolvido na linguagem C# com framework ASP.NET|  ALTA |
|RNF-008| O sistema deverá se comunicar com banco de dados PostgreSQL  |  ALTA |


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Deverá ser desenvolvida uma aplicação interativa: frontend e backend |
|03| O backend é obrigatório ser desenvolvido no framework ASP.NET com a linguagem C# |
|04| O backend é obrigatório ter arquitetura monolítica |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

Paciente
![casos de uso paciente](https://github.com/user-attachments/assets/5f39e76a-88dc-402c-9853-3c8edba3e002)

Médico
![Casos de uso médico](https://github.com/user-attachments/assets/3cfcda56-f82d-4499-88ad-eddf98fa712e)

Consultório
![Casos de uso consultório](https://github.com/user-attachments/assets/872bf90d-288c-4e1c-9118-f6773a16a38c)

