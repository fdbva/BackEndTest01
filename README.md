# BackEndTest01
Code-First, MVC, 4 models with associations


======================
Enunciado
======================
Por favor, avalie o teste e, em seguida, me responda se está apto para
fazer o teste e nos remeter num prazo de 48 horas úteis.

Segue:

Estágio Back-End

 O candidato deverá desenvolver um projeto que consiste na persistência
das seguintes classes:

Turma (Id, Nome, Turno, Ano)

Disciplina (Id, Nome, Professor)

Aluno (Id, Nome, Turma)

Professor(Id, Nome)

Realizar as devidas associações entre as classes e persistir 3 Turmas, 5
Disciplinas,  15 Alunos e 2 Professores em banco local utilizando o Entity
Framework.

Obs: Uma Turma deve possuir uma lista de Alunos. Uma Disciplina pode
pertencer a mais de uma Turma e uma Turma possui diversas Disciplinas.
Sugestão de abordagem para construção do projeto: Code-First.

Prazo de resposta: 48 horas
======================
Fim do Enunciado
======================
Dúvida / Raciocínio:
MVC? Web API?


Associações:
* Turma 1 - * Alunos (one to many)
* Turma * - * Disciplinas (many to many)


* Qual a relação entre Professor e Disciplina?


*	Assumir que a disciplina deve ter pelo menos 1 professor, pois para criar
5 Disciplinas e apenas 2 professores, precisaria ter um professor vinculado a mais do que uma disciplina.
Por causa desse trecho do enunciado: Disciplina (Id, Nome, Professor)
vou considerar que disciplina deve ter pelo menos 1 professor, o que implica
que um professor pode estar vinculado a mais de uma disciplina:

* Professor 1 - * Disciplina (one to many)


* Relação entre Disciplina e Aluno é indireta apenas?


