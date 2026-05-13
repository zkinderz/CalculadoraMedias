# User Stories

## US01 - Calcular Média Semestral

Como usuário do sistema,  
quero informar as notas NP1, NP2 e PIM,  
para que o sistema calcule a média semestral do aluno.

### Critérios de Aceitação

- O sistema deve permitir informar NP1, NP2 e PIM.
- As notas devem estar entre 0,0 e 10,0.
- O sistema deve calcular a média usando os pesos definidos.
- O sistema deve exibir a média semestral com uma casa decimal.

---

## US02 - Definir Status Semestral

Como usuário do sistema,  
quero visualizar o status do aluno após o cálculo semestral,  
para saber se ele foi aprovado, reprovado ou ficou em exame.

### Critérios de Aceitação

- Se a média semestral for maior ou igual a 7,0, o status deve ser Aprovado.
- Se a média semestral for menor que 4,0, o status deve ser Reprovado.
- Se a média semestral estiver entre 4,0 e 6,9, o status deve ser Em Exame.

---

## US03 - Calcular Média Final

Como usuário do sistema,  
quero informar a nota do exame,  
para que o sistema calcule a média final do aluno.

### Critérios de Aceitação

- O campo Exame deve ser habilitado apenas quando o aluno estiver em exame.
- A nota do exame deve estar entre 0,0 e 10,0.
- O sistema deve calcular a média final usando a média semestral e a nota do exame.

---

## US04 - Definir Status Final

Como usuário do sistema,  
quero visualizar o status final do aluno após o exame,  
para saber se ele foi aprovado ou reprovado.

### Critérios de Aceitação

- Se a média final for maior ou igual a 5,0, o status deve ser Aprovado.
- Se a média final for menor que 5,0, o status deve ser Reprovado.

---

## US05 - Limpar Dados Semestrais

Como usuário do sistema,  
quero limpar os campos da média semestral,  
para iniciar um novo cálculo.

### Critérios de Aceitação

- O botão Limpar Semestral deve limpar NP1, NP2, PIM, Exame, Média Semestral e Média Final.
- O status deve voltar para Em Andamento.
- O campo Exame deve ser desabilitado.

---

## US06 - Limpar Dados Finais

Como usuário do sistema,  
quero limpar apenas os dados do exame,  
para refazer o cálculo da média final.

### Critérios de Aceitação

- O botão Limpar Final deve limpar o campo Exame.
- O botão Limpar Final deve limpar a Média Final.
- O status deve voltar para Em Exame.

---

## US07 - Validar Notas

Como sistema,  
quero validar as notas informadas,  
para evitar cálculos incorretos.

### Critérios de Aceitação

- O sistema não deve aceitar notas menores que 0,0.
- O sistema não deve aceitar notas maiores que 10,0.
- O sistema deve exibir mensagem de erro para valores inválidos.
