# QyonAdventureWorks
##### Por: [@matheussanton](https://github.com/matheussanton)

## Sobre o projeto

Essa aplicação tem como intuito demonstração de habilidades na construção de uma API REST,
integrada à banco de dados Postgres, utilizando rotas para um *CRUD* de competidores, pistas de
corridas e histórico de corridas.


## Funcionalidades

- [x]   CRUD de competidores.
- [x]   CRUD de pistas.
- [x]   Leitura, inserção e alteração do Histórico de Corridas.
- [x]   Listagem das pistas utilizadas.
- [x]   Listagem de competidores e respectivos tempos médios de Corridas.
- [x]   Listagem de competidores sem histórico de corridas.

## Futuras Implementações
- [ ]   Upload da Aplicação em produção utilizando Heroku
- [ ]   Conexão com banco Postgres em produção utilizando Heroku

## MER da Aplicação

![App Screenshot](https://media.discordapp.net/attachments/933832873604182077/970499773373227078/qyonerd.png)

## Container (Docker)

```bash
docker pull matheussanton/image_qyonapi [OUT OF DATE]
```

# Documentação da API
## Competidores

### Retorna todos os competidores
```http
  GET /api/Competidores
```
- Retorno de exemplo:
```
[
    {
        "id": "string",
        "nome": "string",
        "sexo": "string",
        "temperaturaMediaCorpo": "string",
        "peso": "string",
        "altura": "string"
    }
]
```

### Inclusão de um novo competidor
```http
  POST /api/Competidores
```

-  Parâmetros:
  ```
{
    "nome": "string",
    "sexo": "string",
    "temperaturaMediaCorpo": "string",
    "peso": "string",
    "altura": "string"    
}
  ```

-  Retorno:
  ```
    {
      "retorno": "string",
      "problema": [
        {
          "descricao": "string"
        }
      ]
    }
  ```

  ### Alteração de um competidor
```http
  PUT /api/Competidores
```

-  Parâmetros:
  ```
  {
    "id": "string",
    "nome": "string",
    "sexo": "string",
    "temperaturaMediaCorpo": "string",
    "peso": "string",
    "altura": "string"
  }
  ```

-  Retorno:
  ```
    {
      "retorno": "string",
      "problema": [
        {
          "descricao": "string"
        }
      ]
    }
  ```

### Exclusão de um competidor
```http
  DELETE /api/Competidores
```

-  Parâmetros:
  ```
  {
    "id": "string"
  }
  ```

-  Retorno:
  ```
    string
  ```

## Pistas de Corrida


### Retorna todas as Pistas de Corrida
```http
  GET /api/PistaCorrida
```
- Retorno de exemplo:
```
[
    {
        "id": "string",
        "descricao": "string"
    }
]
```

### Inclusão de uma nova Pista
```http
  POST /api/PistaCorrida
```

-  Parâmetros:
  ```
{
    "descricao": "string"
}
  ```

-  Retorno:
  ```
string
  ```

  ### Alteração de uma Pista
```http
  PUT /api/PistaCorrida
```

-  Parâmetros:
  ```
  {
  "id": "string",
  "descricao": "string"
}
  ```

-  Retorno:
  ```
string
  ```

### Exclusão de uma Pista
```http
  DELETE /api/PistaCorrida
```

-  Parâmetros:
  ```
  {
  "id": "string"
}
  ```

-  Retorno:
  ```
string
  ```
## Histórico de Corridas

### Retorna o Histórico de Corridas
```http
  GET /api/HistoricoCorrida
```
- Retorno de exemplo:
```
[
  {
    "id": "string",
    "competidorId": "string",
    "pistaCorridaId": "string",
    "dataCorrida": "string",
    "tempoGasto": "string"
  }
]
```

### Inclusão de um novo Histórico
```http
  POST /api/HistoricoCorrida
```

-  Parâmetros:
  ```
{
    "competidorId": "string",
    "pistaCorridaId": "string",
    "dataCorrida": "string",
    "tempoGasto": "string"
}
  ```

-  Retorno:
  ```
string
  ```

  ### Alteração de um Histórico
```http
  PUT /api/HistoricoCorrida
```

-  Parâmetros:
  ```
{
  "id": "string",
  "competidorId": "string",
  "pistaCorridaId": "string",
  "dataCorrida": "string",
  "tempoGasto": "string"
}

  ```

-  Retorno:
  ```
string
  ```
## Outros métodos de listagem

### Listagem de Competidores sem Histórico
```http
  GET /api/ListaCompetidoresSemHistorico
```
- Retorno de exemplo:
```
[
  {
    "id": "string",
    "nome": "string",
    "sexo": "string",
    "temperaturaMediaCorpo": "string",
    "peso": "string",
    "altura": "string"
  }
]
```

### Listagem de Pistas de corrida utilizadas
```http
  GET /api/ListaPistasUtilizadas
```
- Retorno de exemplo:
```
[
  {
    "id": "string",
    "descricao": "string"
  }
]
```

### Listagem do tempo médio dos competidores em seus históricos
```http
  GET /api/ListaTempoMedioCompetidores
```
- Retorno de exemplo:
```
[
  {
    "id": "string",
    "nome": "string",
    "tempoMedio": "string"
  }
]
```
