# Calculadora de Médias

## Descrição

Aplicação Desktop desenvolvida em C# com Windows Forms para calcular a média semestral e a média final de alunos.

O projeto possui uma biblioteca de classes com as regras de negócio e testes unitários utilizando xUnit.

## Tecnologias Utilizadas

- C#
- .NET 8
- Windows Forms
- xUnit
- Git/GitHub

## Estrutura do Projeto

CalculadoraMedias
- CalculadoraMedias.Core
- CalculadoraMedias.Desktop
- CalculadoraMedias.Tests

## Regras de Negócio

### Média Semestral

Média Semestral = NP1 * 0,4 + NP2 * 0,4 + PIM * 0,2

### Status Semestral

- Média Semestral >= 7,0: Aprovado
- Média Semestral < 4,0: Reprovado
- Média Semestral entre 4,0 e 6,9: Em Exame

### Média Final

Média Final = (Média Semestral + Exame) / 2

### Status Final

- Média Final >= 5,0: Aprovado
- Média Final < 5,0: Reprovado

## Como Executar

Na pasta principal do projeto, execute:

dotnet build

Depois:

dotnet run --project .\CalculadoraMedias.Desktop\CalculadoraMedias.Desktop.csproj

## Como Executar os Testes

dotnet test

## Exemplos

### Aprovado Direto

NP1 = 8  
NP2 = 7  
PIM = 9  

Média Semestral = 7,8  
Status = Aprovado  

### Em Exame e Aprovado

NP1 = 5  
NP2 = 6  
PIM = 5  
Exame = 7  

Média Semestral = 5,4  
Média Final = 6,2  
Status = Aprovado  

### Em Exame e Reprovado

NP1 = 5  
NP2 = 3  
PIM = 4  
Exame = 2  

Média Semestral = 4,0  
Média Final = 3,0  
Status = Reprovado  

## Autor

Projeto desenvolvido para fins acadêmicos.
