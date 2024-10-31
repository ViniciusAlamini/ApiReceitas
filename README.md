# API de Receitas

Esta é uma API desenvolvida em ASP.NET Core que permite buscar receitas através de um gateway API, utilizando a Forkify API para fornecer informações sobre várias receitas.


- **URL:** `/apigateway/receitas`
- **Método:** `GET`
- **Parâmetros:**
  - `receita` (string): O nome da receita que você deseja buscar.
- **Exemplo de Uso:**
  ```http
  GET /apigateway/receitas?receita=pizza
  ```
## Resposta
```Json
{
    "count": 28,
    "receitas": [
        {
            "publisher": "101 Cookbooks",
            "title": "Best Pizza Dough Ever",
            "source_url": "http://www.101cookbooks.com/archives/001199.html",
            "recipe_id": "47746",
            "image_url": "http://forkify-api.herokuapp.com/images/best_pizza_dough_recipe1b20.jpg",
            "social_rank": 100
        },
        ...
    ]
}

```

## Tecnologias Usadas
-ASP.NET Core

-C#

-HttpClient

-JSON

## Como Executar o Projeto
1. Clone este repositório:
```terminal
 git clone https://github.com/ViniciusAlamini/ApiReceitas.git
```
2.Execute o projeto:
```terminal
 dotnet run
```
