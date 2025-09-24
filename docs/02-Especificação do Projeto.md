# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

# PERSONA 1
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" 
     alt="Persona1" width="400"/>

### João Silva 

Idade: 42 anos

Profissão: Trabalhador autônomo (pintor de paredes)

Localização: Contagem, MG

Formação: Ensino fundamental incompleto

Objetivo: Ter acesso a consultas médicas gratuitas e rápidas. 

## Descrição:
João é um trabalhador autônomo que não tem condições financeiras de manter um plano de saúde. Depende exclusivamente do SUS, mas enfrenta dificuldades com filas longas e demora para consultas. Ele busca alternativas mais ágeis e acessíveis.

## Dores:

Dificuldade para conseguir consultas pelo SUS.

Não tem tempo para esperar horas em postos de saúde.

Pouca familiaridade com tecnologia.

## Expectativas:

Um sistema simples, rápido e gratuito para marcar consultas.

Sentir confiança no serviço, sem burocracia.

# PERSONA 2
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" 
     alt="Persona1" width="400"/>

### Médica Voluntária – Dra. Mariana Rocha

Idade: 34 anos

Profissão: Médica clínica geral

Localização: Belo Horizonte, MG

Formação: Medicina pela UFMG, residência em Clínica Geral

Objetivo: Contribuir com a sociedade oferecendo consultas gratuitas. 

## Descrição:
Dra. Mariana atua em um hospital particular, mas sente falta de devolver à sociedade parte do que conquistou. Quer participar de campanhas sociais oferecendo consultas para pacientes carentes.

## Dores:

Dificuldade em encontrar plataformas confiáveis de voluntariado.

Falta de organização em campanhas de saúde comunitária.

Desejo de ter clareza sobre pacientes e horários.

## Expectativas:

Plataforma organizada para visualizar pacientes e horários.

Agendamento simples e possibilidade de cancelamento fácil.

# PERSONA 3
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" 
     alt="Persona1" width="400"/>

### Gestora de Consultório – Carla Menezes

Idade: 40 anos

Profissão: Administradora de consultório médico

Localização: São Paulo, SP

Formação: Administração de Empresas

Objetivo: Organizar campanhas de saúde gratuitas para a comunidade. 

## Descrição:
Carla gerencia um consultório que deseja participar de campanhas sociais como forma de responsabilidade social. Precisa de um sistema que conecte médicos voluntários e pacientes de baixa renda.

## Dores:

Falta de ferramentas práticas para gerenciar campanhas.

Dificuldade em monitorar médicos voluntários.

Pouco controle sobre agendamentos.

## Expectativas:

Criar campanhas de forma simples.

Acompanhar médicos voluntários e seus atendimentos.

# PERSONA 4
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" 
     alt="Persona1" width="400"/>

### Estudante Universitária – Luana Ferreira

Idade: 21 anos

Profissão: Estudante de Enfermagem

Localização: Salvador, BA

Formação: Graduação em andamento

Objetivo: Ter acompanhamento médico gratuito para manter saúde em dia. 

## Descrição:
Luana é estudante bolsista e não tem plano de saúde. Precisa de consultas básicas para manter acompanhamento médico, mas muitas vezes adia exames e atendimentos por falta de acesso.

## Dores:

Falta de dinheiro para consultas particulares.

Dificuldade em agendar consultas no SUS devido à demora.

Falta de informações sobre campanhas gratuitas.

## Expectativas:

Conseguir marcar consultas sem burocracia.

Ter um histórico digital para acompanhar seus atendimentos.

# PERSONA 5
<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" 
     alt="Persona1" width="400"/>

### Idosa Aposentada – Dona Maria Aparecida

Idade: 68 anos

Profissão: Aposentada (ex-professora de ensino fundamental)

Localização: Recife, PE

Formação: Magistério

Objetivo: Acesso fácil a consultas médicas gratuitas para cuidar da saúde.

## Descrição:
Dona Maria depende da aposentadoria para viver e não tem condições de pagar convênio. Tem problemas de hipertensão e precisa de acompanhamento frequente.

## Dores:

Longa espera por consultas no SUS.

Dificuldade em lidar com aplicativos complicados.

Preocupação constante com saúde e medicamentos.

Falta de informações sobre campanhas gratuitas.

## Expectativas:

Sistema simples, com botões grandes e intuitivos.

Poder contar com apoio de familiares para agendar consultas.

Segurança de que terá atendimento garantido.


# Perfis de Usuários

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
