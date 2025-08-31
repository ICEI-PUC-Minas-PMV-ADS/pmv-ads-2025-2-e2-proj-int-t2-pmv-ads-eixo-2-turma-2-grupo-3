# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

Identifique, em torno de, 5 personas. Para cada persona, lembre-se de descrever suas angústicas, frustrações e expectativas de vida relacionadas ao problema. Além disso, defina uma "aparência" para a persona. Para isso, você poderá utilizar sites como [https://this-person-does-not-exist.com/pt#google_vignette](https://this-person-does-not-exist.com/pt) ou https://thispersondoesnotexist.com/ 

Utilize também como referência o exemplo abaixo:

<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" alt="Persona1"/>

Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:

> **Links Úteis**:
> 
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Ana Clara  | Uma forma de identificar se uma agência é realmente confiável           | Me sentir mais segura ao contratar seus serviços               |
|Ana Clara       | Ter um mecanismo eficiente e rápido de comunicação                 | Que eu possa sanar todas as minhas dúvidas rapidamente |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

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
<img width="975" height="533" alt="Diagrama casos de uso" src="https://github.com/user-attachments/assets/9876bfd6-6fb2-462e-b168-ddd4be241f99" />

Médico
![Diagrama casos de uso (4)](https://github.com/user-attachments/assets/74cf18bc-e516-4c7f-98d2-9f5db12b4fb6)

Consultório
![Diagrama casos de uso (5)](https://github.com/user-attachments/assets/e3e26ca4-cf7c-49f4-9c8d-d27646df0370)
