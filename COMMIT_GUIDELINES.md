# 📘 Documentação de Orientações de Commit (GitFlow)
## 🔁 Fluxo de trabalho

Usaremos um modelo simplificado de GitFlow, com 3 branches principais:

`main` -> versão estável e pronta para produção

`develop` -> onde o desenvolvimento principal ocorre

`docs` -> onde centralizamos apenas alterações de documentação (README, manuais, etc.)

## 🔧 Regras de uso
| Branch    | Para que serve | Quem pode alterar diretamente |
|-----------|----------------|-------------------------------|
| `main`    | Código estável e testado | Somente via Pull Request |
| `develop` | Desenvolvimento principal | Somente via Pull Request |
| `docs`    | Documentação (README, guias, etc.) | Todos |

## ✅ Como fazer commits corretamente
### 📌 Boas práticas de commit

1. Commits pequenos sem muitos arquivos e muitas alterações, com propósito único
2. Mensagens claras e padronizadas (veja abaixo)
3. Commitar apenas o que realmente precisa ir para o repositório

## 📝 Padrão de mensagens de commit
Formato -> tipo de tarefa: mensagem

Exemplos:

```
feat: adicionar botão de login na tela inicial
fix: corrigir erro de validação de email no cadastro
docs: atualizar README com instruções de instalação
refactor: melhorar legibilidade da função de autenticação
style: aplicar prettier no arquivo de login.js
```

Tipos de tarefas mais comuns:

| Nomenclatura | Designação |
|--------------|------------|
| feat     | nova funcionalidade |
| fix      | correção de bug |
| docs     | documentação |
| style    | formatação (espaços, indentação, etc.) |
| refactor | refatoração de código |
| test     | testes automatizados |
| chore    | tarefas técnicas (configs, etc.) |

## 🔄 Fluxo de trabalho sugerido
### 1. Criar uma branch a partir da develop
```
git checkout develop
git pull
git checkout -b feat/nome-da-funcionalidade
```
### 2. Trabalhar, commitar e subir
```
git add .
git commit -m "feat: adicionar nova funcionalidade X"
git push origin feat/nome-da-funcionalidade
```
### 3. Abrir um Pull Request (PR) para merge na develop
Dica para iniciantes: sempre que possível, peça revisão de outro colega antes de dar merge!
