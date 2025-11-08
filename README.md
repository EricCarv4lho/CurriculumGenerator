# Projeto .NET - Curriculum Generator

Este projeto é uma aplicação ASP.NET Core que permite gerar currículos em formato PDF de forma automatizada. A aplicação recebe dados estruturados via API e utiliza a biblioteca **iText** para criar documentos personalizados. É ideal para sistemas de recrutamento, plataformas de RH ou qualquer aplicação que precise criar currículos dinamicamente.

## Tecnologias Utilizadas
- **ASP.NET Core**: Framework para construção de APIs RESTful em C#.
- **iText**: Biblioteca para geração e manipulação de arquivos PDF.
- **Swagger**: Para documentação e testes da API.


## Funcionalidades
- **Gerar Currículo PDF**: Cria um currículo personalizado com base nos dados enviados.

## Endpoints

### Gerar Currículo
- **Endpoint**: `/api/curriculum/generate`
- **Método**: `POST`
- **Descrição**: Gera um currículo em PDF com os dados fornecidos.

Como Executar
Clone o repositório:
```json
bash
git clone https://github.com/EricCarv4lho/CurriculumGenerator.git

```
Restaure os pacotes:
```json
bash
dotnet restore
```
Execute a aplicação:
```json
bash
dotnet run
```
