
# Projeto de Interface

Visão geral da interação do usuário com as funcionalidades que fazem parte do sistema sociotécnico (protótipo de telas).

## Telas públicas/compartilhadas
 *Estas são as telas visíveis e acessíveis para todos os usuários.*

### 1) Login

- Ao acessar o site, essa é a tela inicial que você encontrará.
- Utilize um "nome de usuário" (como um apelido) e senha para entrar na plataforma.
- Os usuários têm a possibilidade de recuperar sua senha, se cadastrar ou acessar o acervo como usuário convidado.

![Tela de Login](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Login.png)

### 2) Cadastre-se

- Esta tela é dedicada ao cadastro, onde você preenche os campos de Nome Completo, Nome de Usuário, Telefone e Senha.
- Os usuários têm a escolha de realizar o login com suas credenciais, caso já tenha um cadastro, ou acessar o acervo como usuário convidado.

![Tela de Cadastro](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Cadastro.png)

## Telas de Usuário convidado/visitante 
  *Esta é a área onde usuários que não fizeram login ou não possuem uma conta, podem acessar o acervo e utilizar o filtro de pesquisa.*

### 1) Home

- Ao clicar em "Acessar o Acervo" na tela de login, você será direcionado para a tela inicial, onde pode utilizar o filtro de pesquisa, explorar o acervo e, se já tiver um cadastro, fazer login.

![Home - Modo Convidado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Home%20-%20guest.png)

### 2) Home - Filtros de Pesquisa

- O filtro de pesquisa é uma maneira personalizada de explorar o acervo, mostrando somente os resultados relevantes para a busca do usuário.

![Home - Filtros para pesquisa no acervo](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Home%20-%20Filtros.png)

## Telas de Usuários Logados 
  *Essas telas contêm funcionalidades e informações que exigem autenticação do Usuário.*

### 1) Home 

- Após o usuário fazer login, esta é a primeira tela que ele encontrará.
- Você terá acesso ao acervo, seu perfil, seus livros favoritos, poderá fazer reservas de obras, renovar reservas e muito mais a partir desta tela inicial.

![Home - Usuário já está logado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/home-logado.png)

### 2) Home - Resultados de pesquisa ao acervo 

- Depois de definir suas preferências no Filtro, uma seleção personalizada de obras que se alinham com suas escolhas será apresentada.
- Nessa tela, é possível verificar a disponibilidade de um livro, adicioná-lo à lista de favoritos ou removê-lo, e explorar detalhes sobre cada obra.

![Home - Pesquisa ao acervo (Usuário)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/pesquisa-acervo-usuario.png)

### 3) Detalhes - Livro

- Esta é a tela de prévia que apresenta informações sobre um livro em particular.
- Inclui a capa, o título e o autor do livro.
- Se houver mais obras do mesmo autor, serão destacadas na seção "Mais obras deste Autor".
- Indica se o livro está disponível ou indisponível.
- Permite aos usuários reservar o livro (botão Reservar).
- Fornece uma visão geral com a Data de Publicação, Editora, Número de Páginas e uma sinopse.
- Área onde é possível adicionar comentários pessoais sobre o livro.
- Exibe comentários feitos por outros leitores sobre o livro.

![Detalhes - Livro](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/preview-comentarios.png)

### 4) Livros favoritos

- Nesta tela, você pode ver os livros que são de interesse para o usuário, ou seja, os que foram marcados como favoritos por ele.
- Há um botão disponível para visualizar os detalhes e o status de cada livro individualmente.

![Livros favoritos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/favoritos.png)

### 5) Home - Dropdown de perfil

- Quando você clica na foto do usuário, um menu suspenso é exibido, oferecendo as opções de "Perfil" e "Sair". Ao selecionar uma dessas opções, você será redirecionado para a página correspondente.

![Dropdown de perfil](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/home-dropdown-perfil.png)

### 6) Perfil do usuário

- Esta tela apresenta a foto do usuário, que pode ser atualizada.
- Inclui um campo que exibe a quantidade de livros já lidos.
- Os usuários podem atualizar o Nome de Usuário e o Telefone.

![Perfil do usuário](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/perfil-do-usuario.png)

### 7) Minhas Reservas

- Nesta tela, é possível visualizar os livros já devolvidos, os que estão com empréstimo ativo e aqueles com entrega em atraso.
- Também estão disponíveis duas opções cruciais: renovar empréstimo e alterar local de coleta do livro.


![Minhas Reservas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/minhas-reservas.png)

### 8) Alterar local de coleta

-Nesta tela (modal), você pode visualizar o local de entrega e tem a opção de alterar o local de coleta.

![Alterar local de coleta](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/alterar-local.png)

### 9) Reservar

- Nesta tela (modal), você tem a opção de escolher tanto o local de entrega quanto o local de coleta para a reserva.

![Reservar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/reservar.png)

### 10) Renovar

- Nesta tela (modal), você pode visualizar o livro que deseja renovar. Há um campo com opção de Radio Button que permite escolher se deseja manter o local de coleta ou alterá-lo.
- Se o usuário optar por alterar o local de coleta, será exibida a opção para fazer essa modificação.

![Renovar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/renovar.png)

### 11) Confirmação de Reserva

- Nesta tela (modal), o usuário verá a confirmação da reserva. Também será exibido um aviso informando que a entrega será feita em até 48 horas.

![Confirmação de Reserva](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/confirmacao-reserva.png)

## Telas de Administrador 
  *Esta é a área onde os Administradores da biblioteca têm permissões e controles mais amplos sobre o sistema em comparação com os usuários regulares.* 

### 1) Home - Administrador

- Nesta tela, os administradores têm acesso ao Menu (Drawer) contendo opções específicas e a diversos dashboards que fornecem informações relevantes, agilizando o controle e gestão eficientes da biblioteca.

![Home - Administrador](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/home-admin.png)

### 2) Home - Resultados de pesquisa ao acervo (Administrador)

- Após aplicar suas preferências no Filtro de Pesquisa, você verá uma seleção personalizada de obras que correspondem às suas escolhas.
- Nesta tela, é possível visualizar o status do livro (disponível ou indisponível), explorar detalhes sobre cada obra e verificar em qual prateleira o livro está localizado. Além disso, o Menu (Drawer) está adaptado para atender às necessidades do Administrador.

![Home - Pesquisa ao acervo (Administrador)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/pesquisa-acervo-admin.png)

