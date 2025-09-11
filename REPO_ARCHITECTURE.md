# 📁 Documentação de Organização de Diretórios (Monolito Modularizado)
## 🗂 Estrutura base do projeto

```
projeto-raiz/
│
├── src/                  # Código-fonte principal
│   ├── frontend/         # Frontend (HTML, CSS, JS)
│   │   ├── html/
│   │   ├── css/
│   │   ├── js/
│   │   └── img/          # imagens utilizadas nas telas
│   │
│   └── backend/          # Backend (ASP.NET)
│       ├── Controllers/
│       ├── Models/
│       ├── Services/
│       └── Repositories/
│
├── docs/                 # Documentação do projeto (usada pela branch docs)
│   ├── documentações a serem entregues
│
│
├── .gitignore
├── CODE_STYLE.md
├── COMMIT_GUIDELINES.md
├── REPO_ARC.md
├── README.md             # Visão geral do projeto
└── LICENSE
```

## 📌 Regras de organização

* Tudo que é código-fonte fica em *src/*
* Documentações não vão em *src/*, mas sim em *docs/*
* Nada de arquivos soltos na raiz além do *README.md, .gitignore* e *documentações sobre padrões de projeto*
