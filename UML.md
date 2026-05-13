# Diagrama UML

## Diagrama de Classes

```mermaid
classDiagram

class StatusAluno {
    <<enumeration>>
    EmAndamento
    Aprovado
    Reprovado
    EmExame
}

class ResultadoMedia {
    +decimal Media
    +StatusAluno Status
}

class CalculadoraMediaService {
    +CalcularMediaSemestral()
    +DefinirStatusSemestral()
    +CalcularMediaFinal()
    +DefinirStatusFinal()
    -ValidarNota()
    -ValidarPesos()
}

class Form1 {
    -CalculadoraMediaService calculadoraService
    -TextBox txtNp1
    -TextBox txtNp2
    -TextBox txtPim
    -TextBox txtExame
    -TextBox txtMediaSemestral
    -TextBox txtMediaFinal
    -Label lblStatus
    -Button btnSemestral
    -Button btnFinal
}

ResultadoMedia --> StatusAluno
CalculadoraMediaService --> ResultadoMedia
CalculadoraMediaService --> StatusAluno
Form1 --> CalculadoraMediaService
```

## Explicação

O projeto é dividido em três camadas principais:

- `CalculadoraMedias.Core`
  - Contém as regras de negócio.
  - Calcula média semestral, média final e status do aluno.

- `CalculadoraMedias.Desktop`
  - Contém a interface gráfica em Windows Forms.
  - Utiliza a biblioteca Core para realizar os cálculos.

- `CalculadoraMedias.Tests`
  - Contém os testes unitários com xUnit.

## Classes Principais

### StatusAluno

Enum que representa os possíveis status:

- EmAndamento
- Aprovado
- Reprovado
- EmExame

### ResultadoMedia

Classe usada para retornar:

- Média calculada
- Status do aluno

### CalculadoraMediaService

Classe responsável por:

- Calcular média semestral.
- Calcular média final.
- Validar notas.
- Definir status do aluno.

### Form1

Tela principal da aplicação.

Responsável por:

- Receber as notas.
- Exibir os resultados.
- Controlar os botões da interface.# Diagrama UML

## Diagrama de Classes

```mermaid
classDiagram

class StatusAluno {
    <<enumeration>>
    EmAndamento
    Aprovado
    Reprovado
    EmExame
}

class ResultadoMedia {
    +decimal Media
    +StatusAluno Status
}

class CalculadoraMediaService {
    +CalcularMediaSemestral()
    +DefinirStatusSemestral()
    +CalcularMediaFinal()
    +DefinirStatusFinal()
    -ValidarNota()
    -ValidarPesos()
}

class Form1 {
    -CalculadoraMediaService calculadoraService
    -TextBox txtNp1
    -TextBox txtNp2
    -TextBox txtPim
    -TextBox txtExame
    -TextBox txtMediaSemestral
    -TextBox txtMediaFinal
    -Label lblStatus
    -Button btnSemestral
    -Button btnFinal
}

ResultadoMedia --> StatusAluno
CalculadoraMediaService --> ResultadoMedia
CalculadoraMediaService --> StatusAluno
Form1 --> CalculadoraMediaService
```

## Explicação

O projeto é dividido em três camadas principais:

- `CalculadoraMedias.Core`
  - Contém as regras de negócio.
  - Calcula média semestral, média final e status do aluno.

- `CalculadoraMedias.Desktop`
  - Contém a interface gráfica em Windows Forms.
  - Utiliza a biblioteca Core para realizar os cálculos.

- `CalculadoraMedias.Tests`
  - Contém os testes unitários com xUnit.

## Classes Principais

### StatusAluno

Enum que representa os possíveis status:

- EmAndamento
- Aprovado
- Reprovado
- EmExame

### ResultadoMedia

Classe usada para retornar:

- Média calculada
- Status do aluno

### CalculadoraMediaService

Classe responsável por:

- Calcular média semestral.
- Calcular média final.
- Validar notas.
- Definir status do aluno.

### Form1

Tela principal da aplicação.

Responsável por:

- Receber as notas.
- Exibir os resultados.
- Controlar os botões da interface.