# Food VS Fungus 🍔🍄

[![Unity Version](https://img.shields.io/badge/Unity-6000.0.46f1_LTS-black.svg?style=for-the-badge&logo=unity)](https://unity.com/)
[![C# Version](https://img.shields.io/badge/C%23-%23178600.svg?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%2F%20PC-blue?style=for-the-badge)](https://github.com/)

**Food VS Fungus** é um jogo de plataforma 2D desenvolvido em **Unity 6** como Trabalho de Conclusão de Curso (TCC) do curso técnico. O projeto conta a jornada de um carismático hambúrguer herói que luta para purificar a cozinha contra uma infestação de fungos malignos que transformaram os outros alimentos em zumbis.

---

## 📖 História & Universo

Em uma cozinha comum, um vírus fúngico misterioso e maligno começa a se espalhar, assumindo o controle da mente dos alimentos e transformando-os em zumbis hostis. O nosso protagonista, um **Hambúrguer** destemido equipado com um chapéu de mestre-cuca, decide lutar para libertar a cozinha.

A progressão do jogo segue a própria lógica do ambiente de uma cozinha real:
* ❄️ **Freezer & Geladeira:** Zumbis congelados, sorvetes mutantes e carnes congeladas. Um ambiente mais tranquilo, mas escorregadio.
* 🔥 **Forno & Fogão:** Zumbis flamejantes e armadilhas de fogo. Fases tensas e perigosas que exigem reflexos rápidos.
* 🍳 **Bancadas & Pias:** Onde o herói busca ingredientes para criar o antídoto e purificar o lar de uma vez por todas.

---

## 🎮 Mecânicas & Gameplay

* **Customização por Ingredientes (Power-Ups):** Ao derrotar inimigos e explorar os mapas, você coleta ingredientes (como queijo, bacon, mostarda, cebola, etc.). No **Menu de Equipamentos (Inventário)**, você pode misturar estes ingredientes ao corpo do Hambúrguer para alterar seus atributos e ganhar habilidades únicas (ex: super velocidade, pulos duplos, dashes, maior armadura).
* **Combate Dinâmico:** O herói começa com uma *Espada de Batata Frita*, mas pode equipar outras armas ao longo do caminho, como *Armas de Ketchup* e um *Chicote de Macarrão*.
* **Progressão com Chefes:** O jogo é composto por fases temáticas. A cada 5 fases concluídas, o jogador enfrenta um chefão desafiador para progredir na história.
* **Sistema de Vidas:** O jogador possui corações que representam a vida atual. Perder todos os corações custa 1 vida. O jogador tem 3 vidas no total antes do Game Over, com possibilidade de conseguir vidas extras progredindo no jogo.

---

## ⌨️ Controles

| Ação | Tecla | Descrição |
| :--- | :---: | :--- |
| **Movimentação** | `←` `→` `↑` `↓` (Setas) | Movimenta o Hambúrguer e escala superfícies |
| **Pular** | `Z` | Pula (suporta pulo duplo se tiver a habilidade) |
| **Atacar** | `X` | Desfere ataques com a arma equipada |
| **Abrir Inventário** | `I` | Abre o menu de itens e equipar ingredientes |
| **Fechar Inventário** | `Esc` | Fecha o inventário / Pausa o jogo |

---

## ⚙️ Tecnologias & Arquitetura do Projeto

* **Game Engine:** [Unity 6 (Versão 6000.0.46f1)](https://unity.com/)
* **Linguagem:** C#
* **Render Pipeline:** Universal Render Pipeline (URP) para gráficos 2D leves e otimizados
* **Input System:** Novo *Unity Input System* para mapeamento de ações moderno
* **Estilo Artístico & Sonoro:** Gráficos em Pixel Art vibrantes e trilha sonora/efeitos sonoros baseados na era retro de 16-bits (inspirados em clássicos como *Super Mario World*, *Mega Man* e *Kirby*).

---

## 📂 Documentação do Projeto (TCC)

Toda a documentação gerada para o desenvolvimento deste projeto de conclusão de curso está disponível na pasta [`/Documentacao`](file:///C:/Users/ryand/Desktop/FvF/Documentacao) na raiz deste repositório.

* 📄 **[Game Design Document (GDD)](file:///C:/Users/ryand/Desktop/FvF/Documentacao/GDD_FvF.pdf)**: Documento completo detalhando a história, mecânicas, câmera, inimigos e regras de design do jogo.
* 📊 **[Product Backlog](file:///C:/Users/ryand/Desktop/FvF/Documentacao/backlog_FvF.xlsx)**: Planejamento ágil e cronograma de desenvolvimento do projeto.
* ✍️ **[Histórias de Usuário / Estórias](file:///C:/Users/ryand/Desktop/FvF/Documentacao/estorias_FvF.docx)**: Requisitos de funcionalidade sob a ótica dos jogadores.
* 📐 **[Modelagem UML (Astah)](file:///C:/Users/ryand/Desktop/FvF/Documentacao/astah_FvF.asta)**: Modelos de classe e estrutura de banco de dados/lógica do jogo.
* 🖥️ **[Slides de Apresentação](file:///C:/Users/ryand/Desktop/FvF/Documentacao/slides_FvF.pdf)**: Apresentação final utilizada na banca avaliadora do curso técnico.

---

## 🚀 Como Rodar o Projeto na Unity (Guia para Recrutadores)

Siga o passo a passo abaixo para importar e testar o jogo diretamente na Unity no seu computador:

### 1. Pré-requisitos
* Ter o **[Unity Hub](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe)** instalado.
* Instalar a versão específica do editor: **Unity 6 (6000.0.46f1)**. 
  *(Caso não a tenha, o próprio Unity Hub oferecerá o download automático ao tentar abrir o projeto).*

### 2. Baixando o Projeto
Você pode clonar este repositório usando o Git ou baixar o código como ZIP e extraí-lo:
```bash
git clone https://github.com/seu-usuario/FvF.git
```

### 3. Abrindo no Unity Hub
1. Abra o **Unity Hub**.
2. Clique no botão **Add** (Adicionar) -> **Add project from disk** (Adicionar projeto do disco).
3. Selecione a pasta raiz deste repositório (a pasta que contém as subpastas `Assets`, `Packages` e `ProjectSettings`).
4. Clique em **Add Project**.
5. Clique sobre o nome do projeto na lista para abri-lo. *(A primeira abertura pode demorar alguns minutos enquanto a Unity recria a pasta `Library` e importa os assets).*

### 4. Rodando o Jogo no Editor
1. Na aba **Project** (geralmente na parte inferior da tela), navegue até a pasta `Assets` -> `Scenes`.
2. Dê dois cliques no arquivo **`MenuPrincipal.unity`** para abrir a cena inicial.
3. Clique no botão **Play** (ícone de reprodução ⏸️ na parte superior central da tela da Unity) para jogar!

---

## 👥 Equipe & Créditos (Desenvolvedores)

* **Ryan Dias da Silva** ([@seu-perfil-github](https://github.com/)) - Programador Principal, Concepção e Testes.
* **Tiago Ribeiro Moreira Junior** - Programador Principal, Level Design e Experiência do Usuário (UX).
* **Erick da Silva Andrade Marco** - Compositor das Músicas originais e Efeitos Sonoros.
* **Antonio Lamana Neto** - Game Designer, Criação de Mecânicas, Design de Personagens e Animações.

---

*Trabalho de Conclusão de Curso (TCC) finalizado com sucesso em Novembro de 2024. Todos os direitos reservados.*
