# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Arquitetura e Tecnologias

o	Descreva brevemente a arquitetura definida para o projeto e as tecnologias a serem utilizadas. Sugere-se a criação de um diagrama de componentes da solução.

## Project Model Canvas

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/ProjetoGestaoBibliotecaCorporativaCanvas.png>>
</br>

> **Links Úteis**:
> Disponíveis em material de apoio do projeto

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| O sistema deverá permitir o Login de usuários | ALTA | 
|RF-002| O sistema deverá permitir a recuperação de senha   | MÉDIA |
|RF-003| O sistema deverá permitir o cadastro/atualização de usuários (CRUD)   | ALTA |
|RF-004| O sistema deverá permitir o gerenciamento do acervo (CRUD)   | ALTA |
|RF-005| O sistema deverá permitir o gerenciamento de emprestimos (CRUD)   | ALTA |
|RF-006| O sistema deverá registrar os livros lidos pelo usuario   | MÉDIA |
|RF-007| O sistema deverá mostrar um dashboard com informações relevantes ao administrador   | ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser feito usando práticas de UX e IxD | ALTA | 
|RNF-002| O sistema deve ser disponibilizado publicamente no GitHub |  ALTA | 
|RNF-003| O sistema deve apresentar baixo tempo de resposta nas requisições (não superior a 3 segundos |  MÉDIA | 
|RNF-004| O sistema deve ser implementado em C# e Angular |  ALTA | 
|RNF-005| O sistema deve ser responsivo e compatível com os principais navegadores |  MÉDIA | 
|RNF-006| O sistema deve possuir uma versão mobile |  BAIXA | 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01|O projeto deverá ser entregue até o final do EIXO-5 (02/2023) |
|02| Deve ser desenvolvido um módulo de backend em C#        |


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

</br>
<p align="center">
<img src=/Users/Lica/Documents/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/docs/img/Diagramadecasodeuso.rasc.png/>>
</br>


> **Links Úteis**:
## Modelo de Esquema Relacional


O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa. No diagrama abaixo podemos visualizar as entidades mapeadas para o projeto e o relacionamento entre elas.

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/Diagrama%20ER.png>
</p>
</br>

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
