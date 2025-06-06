# SafeZone.API

API desenvolvida para auxiliar na gestão de zonas de risco, moradores, alertas e kits de emergência em regiões afetadas por desastres naturais.

---

## Visão Geral

A SafeZone é uma aplicação desenvolvida em .NET com foco na proteção civil e resposta emergencial. O sistema permite:

* Cadastro e monitoramento de zonas de risco
* Emissão de alertas críticos
* Gerenciamento de moradores residentes nas zonas
* Controle de estoque de kits de emergência
* Interface visual com Razor Pages e navegação por TagHelpers

---

## Tecnologias Utilizadas

* ASP.NET Core 8
* Entity Framework Core (SQLite)
* Swagger / OpenAPI
* Razor Pages com TagHelpers
* REST Services (GET, POST, PUT, DELETE)
* C# com uso de DTOs
* IDE: JetBrains Rider

---

## Diagrama de Entidades

```
ZonaDeRisco
  ├─ id
  ├─ nome
  ├─ tipoEvento
  ├─ status
  ├─ coordenadas
  ├─ Alertas[]
  └─ Moradores[]

Alerta
  ├─ id
  ├─ titulo
  ├─ descricao
  ├─ nivelGravidade
  ├─ dataHora
  └─ zonaDeRiscoId (FK)

Morador
  ├─ id
  ├─ nome
  ├─ cpf
  ├─ prioridade
  └─ zonaDeRiscoId (FK)

KitEmergencia
  ├─ id
  ├─ tipo
  ├─ quantidade
  └─ localEstoque
```

---

## Como Executar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/tcguus/SafeZone.API.git
```

2. Restaure os pacotes:

```bash
dotnet restore
```

3. (Opcional) Crie a migration inicial:

```bash
dotnet ef migrations add InitialCreate
```

4. Atualize o banco de dados:

```bash
dotnet ef database update
```

5. Execute a aplicação:

```bash
dotnet run
```

6. Acesse o Swagger:

[http://localhost:5163/swagger/index.html](http://localhost:5163/swagger/index.html)

---

## Interface Web (Razor Pages)

A aplicação possui uma interface web construída com Razor Pages, que permite:

* Visualizar listas de moradores, zonas de risco, alertas e kits
* Organização de dados em tabelas estilizadas
* Navegação dinâmica entre seções
* Integração direta com Entity Framework Core

Acesse pelo navegador:

[http://localhost:5163/index](http://localhost:5163/index)

---

## Endpoints Disponíveis

### Moradores

* `GET /api/Morador` — Lista todos os moradores
* `POST /api/Morador` — Cadastra um novo morador
* `PUT /api/Morador/{id}` — Atualiza um morador existente
* `DELETE /api/Morador/{id}` — Remove um morador

### Zonas de Risco

* `GET /api/ZonaDeRisco` — Lista todas as zonas
* `POST /api/ZonaDeRisco` — Cadastra nova zona
* `PUT /api/ZonaDeRisco/{id}` — Atualiza zona existente
* `DELETE /api/ZonaDeRisco/{id}` — Remove uma zona

### Kits de Emergência

* `GET /api/KitEmergencia` — Lista todos os kits
* `POST /api/KitEmergencia` — Cadastra um novo kit
* `PUT /api/KitEmergencia/{id}` — Atualiza um kit
* `DELETE /api/KitEmergencia/{id}` — Remove um kit

### Alertas

* `GET /api/Alerta` — Lista todos os alertas
* `POST /api/Alerta` — Emite novo alerta
* `PUT /api/Alerta/{id}` — Atualiza um alerta
* `DELETE /api/Alerta/{id}` — Remove um alerta

---

## 🔪 Exemplos de Testes no Swagger

> **Importante:** Sempre que você criar uma nova **Zona de Risco**, ela receberá um novo `id` automaticamente (por exemplo, `id: 3`).
> Para cadastrar **moradores** ou **emitir alertas** relacionados a essa nova zona, é obrigatório atualizar o campo `"zonaDeRiscoId"` nos testes seguintes com o **id correspondente da nova zona**.

Por exemplo, após criar a zona:

```json
{
  "$id": "2",
  "id": 3,
  "nome": "Zona Sul",
  "tipoEvento": "Deslizamento",
  "status": "Ativo",
  "coordenadas": "-23.55,-45.63"
}
```

Use `"zonaDeRiscoId": 3` nos cadastros de moradores e alertas.

---

### Criar Kit de Emergência

```json
{
  "tipo": "Água potável",
  "quantidade": 10,
  "localEstoque": "Posto de saúde local"
}
```

### Criar Zona de Risco

```json
{
  "nome": "Zona Norte",
  "tipoEvento": "Deslizamento",
  "status": "Ativo",
  "coordenadas": "-23.55,-46.63"
}
```

### Cadastrar Morador

```json
{
  "nome": "Maria Oliveira",
  "cpf": "12345678901",
  "prioridade": "Alta",
  "zonaDeRiscoId": 3  // <-- Atualize com o ID da zona que você criou
}
```

### Emitir Alerta

```json
{
  "titulo": "Calor extremo",
  "descricao": "Temperatura acima de 40ºC",
  "nivelGravidade": "Crítico",
  "dataHora": "2025-05-29T16:30:00",
  "zonaDeRiscoId": 3  // <-- Atualize com o ID da zona que você criou
}
```


---

## Detalhes Técnicos

* Validações automáticas com retorno padronizado (`application/problem+json`)
* DTOs para desacoplamento e proteção da camada de domínio
* Ciclos de referência resolvidos com `ReferenceHandler.Preserve`
* Razor Pages com layout estilizado e CSS inline
* TagHelpers aplicados na navegação entre páginas
* Projeto preparado para integração futura com dispositivos IoT

---

## Integrantes

* Gustavo Camargo de Andrade — RM555562 — 2TDSPF
* Rodrigo Souza Mantovanello — RM555451 — 2TDSPF
* Leonardo Cesar Rodrigues Nascimento — RM558373 — 2TDSPF
