# 🧠 2. Documentação de Desenvolvimento e Melhores Práticas
## 🔹 Frontend: JavaScript (sem frameworks)
### ✅ Boas práticas de JavaScript

* Evite usar *var*, use *const* e *let* sempre que possível
* Evitar duplicação de código, crie funções reutilizáveis
* Nomes claros e bem definidos, funções e variáveis com nomes descritivos
* Evite códigos comentados desnecessários

### 🧪 Exemplo básico
```
// Ruim
function calc(a, b) {
  return a + b;
}

// Bom
function somarNumeros(a, b) {
  return a + b;
}
```
### 🛠 Ferramentas e plugins

* Lint: ESLint
* Formatador: Prettier
* Servidor: LiveServer

## 🔸 Backend: C# com ASP.NET
### ✅ Boas práticas em C# + ASP.NET

Organize por responsabilidades (MVC):

* Controllers: recebem requisições
* Services: lógica de negócio
* Models: classes de dados
* Injeção de dependência: sempre que possível, use Dependency Injection
* Evite código duplicado e funções muito longas
* Use DTOs (Data Transfer Objects) para controlar os dados que entram e saem

### 🧪 Exemplo básico de Controller
```
[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        usuarioService = usuarioService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var usuario = usuarioService.ObterUsuario(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }
}
```
