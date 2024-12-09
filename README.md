# Introduction 
# Movie Awards API

## Como rodar a aplicação
1. Clone o repositório:

```bash
git clone https://github.com/rogeriorfranco/WorstMovieAward.git

cd Worst.Movie.Award.UserInterface

2 Instale as dependências:
dotnet restore
 
3 Rode a aplicação:
dotnet run

4 Acesse o endpoint:
GET http://localhost:8080/awards/api

Testes de Integração
Para rodar os testes de integração:
dotnet test


5 Resultado obtido
{
    "max": [
        {
            "producer": "Matthew Vaughn",
            "interval": 13,
            "previousWin": 2002,
            "followingWin": 2015
        }
    ],
    "min": [
        {
            "producer": "Joel Silver",
            "interval": 1,
            "previousWin": 1990,
            "followingWin": 1991
        }
    ]
}
