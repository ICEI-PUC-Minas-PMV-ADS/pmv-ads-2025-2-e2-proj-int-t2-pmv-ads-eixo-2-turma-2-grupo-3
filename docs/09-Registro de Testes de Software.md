# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

| **Caso de Teste** 	| **CT01 – Cadastrar paciente** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 – A aplicação deve permitir o cadastro de pacientes. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1UEMbUK2S9jOAgVh55FZRhB-ZfMZrStLh/view?usp=drive_link) |

| **Caso de Teste** 	| **CT02 – Cadastrar instituição de saúde** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-02 – A aplicação deve permitir o cadastro de instituições de saúde. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/13B1uS4Rv5WlR73b3qxykSKI6HEDUfHl2/view?usp=drive_link) |

| **Caso de Teste** 	| **CT03 – Validação de campos no cadastro de usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01/02 – O cadastro deve validar obrigatoriedade dos campos. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1QbzZuVqEVpKloPjbIsuRkiTC0tuhF2zm/view?usp=drive_link) |

| **Caso de Teste** 	| **CT04 – Login com sucesso** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01/02 – O cadastro deve validar usuário e senha |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1tqiYkkSWkeyUpt6GoMz0vDgtQq6btYFh/view?usp=drive_link) |

| **Caso de Teste** 	| **CT05 – Login sem sucesso** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01/02 – O cadastro deve validar usuário e senha |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/16VPeLINnv4ZQOYjGSQpgcNM3v9JyV9-l/view?usp=drive_link) |

| **Caso de Teste** 	| **CT06 – Paciente marcar consultas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 – O paciente deve poder agendar consultas |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/14lPW0LVZgBEPADwU1Y3wIx-Dm-sUeJ3v/view?usp=drive_link) |

| **Caso de Teste** 	| **CT07 – Clinica edita médico** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 – A clinica de poder criar, excluir e editar médicos. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1S1HWI4RyylrWkOgVWKktiClg0td0mgmp/view) |

| **Caso de Teste** 	| **CT08 – Clinica exclui médico** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 – A clinica de poder criar, excluir e editar médicos. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1ocBF2BFm_lMCJLOKwFO3HIX0bzom2UaM/view) |

| **Caso de Teste** 	| **CT09 – Clinica cria médico** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 – A clinica de poder criar, excluir e editar médicos. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1I7Hz-1nKhfwdr-Okdscapj4uKxhmPMl5/view) |

| **Caso de Teste** 	| **CT10 – Clinica cria médico sem sucesso** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 – A clinica de poder criar, excluir e editar médicos. |
| Registro de evidência | [Evidência](https://drive.google.com/file/d/1aDQFkc9V9pgmJVHTz10xAGePvHtTxcUy/view) |

## Relatório de testes de software

Os resultados obtidos nos testes foram satisfatórios com exceção de testes além do escopo documentado, os casos de teste: CT6, CT7 e CT11 no plano de testes não foram efetuados devido as funcionalides não terem sido desenvolvidas em tempo hábil.

Pontos fortes: 
- Funcionalidades intuitivas, simples de serem executadas e com tratamentos de erros corretos; 
- Layout responsivo;
- Densidade de informações adequada;

Pontos fracos: 
- Funcionalidades não desenvolvidas conforme escopo do teste;
- Testes fora do escopo;

Os aspectos positivos descritos acima contribuem para que o usuário tenha uma experiência tranquila ao efetuar seu cadastro, login e consecutivamente as ações conforme o tipo de usuário: paciente, médico ou clínica. Enquanto as negativas que ele não poderá efetuar certas ações conforme foi acordado no plano de testes.

Melhorias a serem consideradas:
- Desenvolvimento das funcionalidades faltantes por parte de agendamento de consultas;
- Melhor documentação das rotas conforme verbos HTTP e ações no sistema;
- Possibilitar busca ao selecionar especialidades no cadastro de médico;
- Botão de logout no menu lateral;

> **Ferramentas utilizadas**:
> - [Gravação de tela](https://support.microsoft.com/en-us/windows/use-snipping-tool-to-capture-screenshots-00246869-1843-655f-f220-97299b865f6b)
> - [Editor de video](https://clipchamp.com/pt-br/)
