<img src="transferir.png" width="200" alt="Parfois">
# Back-end Challenge

Nota do desenvolvedor.

-----

#### Informações para executar a aplicação

1. Os projetos foram criados em .Net8.

2. O projecto que deve ser executado primeiro (Startup) é o DesafioBackEnd.WebApi. (Execute a solution).

3. A base de dados é interna (in-memory) e funciona a cada execução. Ou seja, se executar novamente a aplicação, a base é recriada (sem registos).

4. Os testes unitários foram feitos com o Xunit, e quando executados, são criados esses registos na base de dados:
```json
{
  "pedido":"123456",
  "itens": [
  {
    "descricao": "Item A",
    "precoUnitario": 10,
    "qtd": 1
  },
  {
    "descricao": "Item B",
    "precoUnitario": 5,
    "qtd": 2
  }
  ]
}
```

Os testes são feitos tendo por base esses registos.

5. A base de dados dos testes unitários também é in-memory, então é recriada a cada execução.