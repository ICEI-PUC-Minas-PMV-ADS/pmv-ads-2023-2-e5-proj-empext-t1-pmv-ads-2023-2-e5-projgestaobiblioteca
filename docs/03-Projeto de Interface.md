
# Projeto de Interface

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Visão geral da interação do usuário com as funcionalidades que fazem parte do sistema sociotécnico (protótipo de telas).

## Login

- Esta é a primeira tela ao abrir o site.
- Será utilizado "nome de usuário" (como um apelido) e senha para acesso.
- O usuário poderá Recuperar sua senha, se cadastrar ou Acessar o acervo(sem necessidade de realizar o login).


![Tela de Login](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Login.png)

## Cadastre-se

- Tela de cadastro, contendo os campos para Nome Completo, Nome de Usuario, Telefone e senha.
- O usuário poderá Realizar o Login ou Acessar o acervo(sem necessidade de realizar o login).

![Tela de Cadastro](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Cadastro.png)

## Home - Modo de Convidado

- Este é o modo do usuário acessar o acervo, sem a necessidade de realizar o Login.

![Home - Modo Convidado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Home%20-%20guest.png)

## Home - Usuário Logado

- Neste modo o usuário pode acessar o acervo, seu perfil, seus livros favoritos, realizar reserva de obras, etc.

![Home - Usuário já está logado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/home-logado.png)

## Home - Filtros de Pesquisa

- Filtro de pesquisa é uma forma costumizada de realizar consulta no acervo, trazendo apenas os resultados relevantes para o que você está procurando.

![Home - Filtros para pesquisa no acervo](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Home%20-%20Filtros.png)

## Home - Resultados de pesquisa ao acervo (Usuário)

- Após utilizar o Filtro de Pesquisa, será retornado as obras de acordo com o que você selecionou no Filtro.
- Nesta tela será possível visualizar o status do livro (disponível ou indisponível), favoritar ou desfavoritar obras e visualizar detalhes sobre determinado livro.

![Home - Pesquisa ao acervo (Usuário)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/pesquisa-acervo-usuario.png)

## Home - Resultados de pesquisa ao acervo (Administrador)

- Após utilizar o Filtro de Pesquisa, será retornado as obras de acordo com o que você selecionou no Filtro.
- Nesta tela será possível visualizar o status do livro (disponível ou indisponível), visualizar detalhes sobre determinado livro, visualizar a preteleira onde o livro se encontra, e o Menu (Drawer) que é adaptado para atender ás necessidades do Administrador.

![Home - Pesquisa ao acervo (Administrador)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/pesquisa-acervo-admin.png)

## Home - Dropdown de perfil

- Ao clicar na foto do usuário, aparecerá um Dropdown com as opções "Perfil", "Favoritos" e "Sair", que ao serem clicados, redircionarão o usuário ás suas respectivas páginas.

![Dropdown de perfil](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/home-dropdown-perfil.png)

## Detalhes - Livro

- Tela de preview de determinado livro.
- Contém a capa, o nome e o autor do livro.
- Caso haja outras obras desse mesmo autor, haverá uma sessão de "Mais obras desse Autor".
- Status do livro.
- Botão de Reservar.
- Um overview contendo Data de Publicação, Editora, Número de Páginas e uma sinopse do livro.
- Campo para adicionar comentários.
- Comentários de outros leitores.

![Detalhes - Livro](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/preview-comentarios.png)

## Livros favoritos

- Nesta tela, é mostrado os livros que o usuário tem interesse, ou seja, os livros favoritados por ele.
- Botão para visualizar os detalhes de cada livro e o status dele.

![Livros favoritos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/favoritos.png)

## Perfil do usuário

- Tela contendo Foto do Usuário, podendo atualiza-la.
- Campo com a quantidade de livros já lidos.
- Poderá atualizar Nome de Usuário e Telefone. 

![Perfil do usuário](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/perfil-do-usuario.png)

## Minhas Reservas

- Tela para visualizar livros Emprestados (já devolvidos), livros que estão com Emprestimo Ativo e livros com Entrega em Atraso.
- Nesta mesma tela, você poderá acessar os livros Favoritos e os que você já pegou Emprestado.
- Também outras duas opções muito importantes: Renovar Emprestimo e Alterar Local de Coleta do Livro.

![Minhas Reservas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/minhas-reservas.png)

## Alterar local de coleta

- Nesta tela (modal), será possível visualizar o Local de entrega, e alterar o local de coleta.

![Alterar local de coleta](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/alterar-local.png)

## Home - Administrador

- Nesta tela, será possível ver o Menu (Drawer) com as opções específicas para o Administrador, e alguns dashboards com informações relevantes e que agilizem o controle da biblioteca.

![Home - Administrador](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/home-admin.png)

## Reservar

- Nesta tela (modal), será possível selecionar o Local de entrega e o local de coleta da Reserva. 

![Reservar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/reservar.png)

## Renovar

- Nesta tela (modal), será possível visualizar o livro a ser renovado, selecionar em um Radio Button se você deseja manter o local da coleta ou alterá-lo.
- Se o usuário escolher alterar, aparecerá a opção de Alterar o local de coleta.

![Renovar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/renovar.png)

## Confirmação de Reserva

- Nesta tela (modal), o usuário verá a confirmação da sua reserva, e o aviso de que a entrega será feita em até 48h.

![Confirmação de Reserva](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/confirmacao-reserva.png)



