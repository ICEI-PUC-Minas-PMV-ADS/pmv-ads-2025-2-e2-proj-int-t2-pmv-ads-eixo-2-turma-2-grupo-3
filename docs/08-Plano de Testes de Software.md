# Plano de Testes de Software

**1. Objetivo**

Validar se o sistema Cuida+ atende aos requisitos funcionais e não funcionais definidos, garantindo que o processo de cadastro de usuários, login, marcação de consultas, remarcação, cancelamento e a interface baseada no Figma funcionem corretamente, de forma segura e intuitiva.

**2. Escopo**

Os testes contemplarão:
- Cadastro de usuários (paciente e instituição de saúde)
- Login 
- Agendamento de consultas
- Cancelamento e reagendamento

Fora do escopo: integração com sistemas externos de saúde que ainda não estiverem homologados.


**3. Estratégia de Testes**

• Testes Funcionais → validação de requisitos e regras de negócio

• Testes de Validação de Dados → campos obrigatórios, formatos de CPF, e-mail etc.

• Testes de Segurança → login, autenticação e proteção de dados sensíveis

• Testes de Performance → resposta rápida (< 2s em operações principais)

• Testes de Compatibilidade → diferentes navegadores e dispositivo.


**4. Casos de Teste**

**Cadastro de Usuário**

| **Caso de Teste** 	| **CT01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 – A aplicação deve permitir o cadastro de pacientes. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar endereço do sistema - Clicar em "Criar conta" - Preencher os campos obrigatórios (e-mail, nome, sobrenome, celular, CPF, senha, confirmação de senha) <br> - Confirmar senha - Clicar em “Cadastrar” |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT02 – Efetuar login	|
|Requisito Associado | RF-02 – A aplicação deve permitir o cadastro de instituições de saúde. |
| Objetivo do Teste 	| Verificar se a instituição consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar endereço do sistema - Selecionar tipo “Instituição” - Preencher CNPJ, razão social, e-mail e senha - Clicar em “Cadastrar” |
|Critério de Êxito | - Cadastro da instituição concluído com sucesso. |
|  	|  	|
| Caso de Teste 	| CT03 – Campos obrigatórios vazios no cadastro |
|Requisito Associado | RF-01/02 – O cadastro deve validar obrigatoriedade dos campos. |
| Objetivo do Teste 	| Verificar se o sistema exibe mensagem de erro ao tentar cadastrar sem preencher campos obrigatórios. |
| Passos 	| - Acessar o navegador <br> - Informar endereço do sistema - Selecionar tipo “Instituição” - Clicar em “Cadastrar” sem preencher nada |
|Critério de Êxito | Sistema exibe mensagem de erro nos campos obrigatórios. |
|  	|  	|
| Caso de Teste 	| CT04 – Login válido	|
|Requisito Associado | RF-01/02 – O cadastro deve validar obrigatoriedade dos campos. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login com credenciais válidas. |
| Passos 	| - Acessar o navegador <br> - Informar endereço do sistema - Selecionar tipo “Instituição” - Inserir e-mail e senha corretos - Clicar em “Entrar” |
|Critério de Êxito | Login realizado e usuário redirecionado à tela inicial. |
|  	|  	|
| Caso de Teste 	| CT05 – Login inválido (senha errada)	|
|Requisito Associado | RF-03 – A aplicação deve validar credenciais de login. |
| Objetivo do Teste 	| Verificar se o sistema exibe mensagem de erro ao inserir senha incorreta. |
| Passos 	| - Acessar o navegador <br> - Informar endereço do sistema - Inserir e-mail válido e senha incorretaInserir e-mail válido e senha incorreta - Clicar em “Entrar” |
|Critério de Êxito | Mensagem exibida: “Usuário ou senha inválidos”. | 
|  	|  	|
| Caso de Teste 	| CT06 – Agendamento de consulta válido	|
|Requisito Associado | RF-04 – O paciente deve poder agendar consultas. |
| Objetivo do Teste 	| Verificar se o paciente consegue realizar agendamento de consulta. |
| Passos 	| Paciente logado - Acessar tela “Agendar consulta” - Selecionar especialidade - Escolher data, horário e médico - Confirmar agendamento |
|Critério de Êxito | Consulta registrada e exibida em “Minhas Consultas”.| 
|  	|  	|
| Caso de Teste 	| CT7 – Cancelar consulta futura	|
|Requisito Associado | RF-05 – O paciente deve poder cancelar consultas agendadas. |
| Objetivo do Teste 	| Verificar se o usuário consegue cancelar uma consulta já agendada. |
| Passos 	| Acessar “Minhas Consultas” - Selecionar consulta - Clicar em “Cancelar” |
|Critério de Êxito | Status da consulta atualizado para “Cancelada”.| 
|  	|  	|
| Caso de Teste 	| CT11 – Reagendar consulta	|
|Requisito Associado | RF-06 – O paciente deve poder reagendar consultas. |
| Objetivo do Teste 	| Verificar se o usuário consegue reagendar uma consulta já marcada. |
| Passos 	| Acessar “Minhas Consultas” - Selecionar consulta - Clicar em “Reagendar” - Escolher novo horário/dia válido |
|Critério de Êxito | Consulta reagendada com sucesso.|
|  	|  	|
| Caso de Teste 	| CT12 – Consistência visual	|
|Requisito Associado | RNF-01 – A interface deve seguir um sistema limpo e claro. |
| Objetivo do Teste 	| Verificar se a interface do sistema é clara. |
| Passos 	| Executar sistema - Navegação limpa do projeto. |
|Critério de Êxito | Layout consistente.|
|  	|  	|
| Caso de Teste 	| CT13 – Navegação entre telas	|
|Requisito Associado |RNF-02 – O sistema deve permitir navegação fluida entre telas. |
| Objetivo do Teste 	| Verificar se a navegação entre menus funciona corretamente. |
| Passos 	| Usuário logado - Clicar nos menus (Home, Consultas, Perfil). |
|Critério de Êxito | Navegação fluida e sem erros.|

