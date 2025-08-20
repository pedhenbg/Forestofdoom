# Gameconsole - A Text-Based RPG in C#

Um simples RPG de texto por turnos, criado em C# (.NET) como um projeto de estudo para praticar conceitos fundamentais de programação. O objetivo era desenvolver uma aplicação de console interativa, aplicando lógica de jogo, programação orientada a objetos e manipulação de eventos.

## 🎮 Gameplay em Ação

## ✨ Funcionalidades

* **Criação de Personagem:** Inicie sua jornada definindo o nome do seu herói.
* **Exploração Contínua:** Um loop principal de jogo com eventos aleatórios a cada passo.
* **Eventos Aleatórios:** Encontros podem variar entre batalhas, eventos de cura ou momentos de calmaria.
* **Inimigos Aleatórios:** O sistema de "fábrica" seleciona um inimigo diferente de uma lista predefinida a cada batalha.
* **Combate em Turnos:** Sistema de batalha clássico onde jogador e inimigo atacam alternadamente.
* **Sistema de Dano Variável:** O dano é calculado usando uma simulação de rolagem de dado d20, com chances de acerto normal, de raspão, crítico ou falha crítica.

## 🚀 Como Rodar o Projeto

**Pré-requisitos:**
* [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 ou superior)

**Passos:**
1.  Clone o repositório:
    ```bash
    git clone [https://github.com/pedhenbg/Gameconsole.git](https://github.com/pedhenbg/Gameconsole.git)
    ```
2.  Navegue para a pasta do projeto:
    ```bash
    cd Gameconsole
    ```
3.  Execute a aplicação:
    ```bash
    dotnet run
    ```

## 🛠️ Tecnologias Utilizadas

* **C#**
* **.NET**

## 📚 Aprendizados e Próximos Passos

Este projeto foi fundamental para solidificar meu conhecimento em:
* Lógica de um Game Loop (`while` e `switch`).
* Uso da classe `Random` para criar experiências dinâmicas.
* Princípios de Programação Orientada a Objetos (Classes `Player` e `Enemy`).
* Organização de código com métodos auxiliares e o padrão Factory Method.
* Manipulação de Console (`Clear`, `ReadKey`, `SetCursorPosition`).

**Próximos Passos Planejados:**
* [ ] Implementar um sistema de inventário com itens de cura e ataque.
* [ ] Adicionar mais tipos de eventos de exploração.
* [ ] Criar um sistema simples de ganho de experiência (XP) e níveis.
* [ ] Adicionar ASCII Art em algumas partes do projeto.
