# Planos de Testes de Software

## [Backend] - Testes de unidade (automatizados)

**Ferramenta de testes**: xUnit.net (disponilizada para aplicações do .NET Framework)

Foram implementados 24 testes de unidade automatizados, que cobrem os principais métodos das camadas de serviços dos contextos AcervoServices, EmprestimoServices e PatrimonioServices. Para cada método foram implementados dois testes de unidade: um cenário de sucesso e outro de insucesso.

### AcervoServicesTests

**CTU1** - GetAllAcervosAsync_DeveRetornarAListaDeAcervosCadastrados_QuandoExistirAcervosCadastrados<br>
**CTU2** - GetAllAcervosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirAcervosCadastrados<br>
**CTU3** - GetAcervoByIdAsync_DeveRetornarOsDadosDoAcervo_QuandoOIdInformadoForValido<br>
**CTU4** - GetAcervoByIdAsync_NaoDeveRetornarOsDadosDoAcervo_QuandoOIdInformadoForInvalido<br>
**CTU5** - CreateAcervo_DeveRealizarAInclusaoDoAcervo_QuandoOsDadosForemValidos<br>
**CTU6** - CreateAcervo_NaoDeveRealizarAInclusaoDoAcervo_QuandoOsDadosForemInvalidos<br>
**CTU7** - DeleteAcervo_DeveRealizarAExclusaoDoAcervo_QuandoOAcervoExistir<br>
**CTU8** - DeleteAcervo_NaoDeveRealizarAExclusaoDoAcervo_QuandoOAcervoNaoExistir<br>

### EmprestimoServicesTests

**CTU1** - GetAllEmprestimosAsync_DeveRetornarAListaDeEmprestimosCadastrados_QuandoExistirEmprestimosCadastrados<br>
**CTU2** - GetAllEmprestimosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirEmprestimosCadastrados<br>
**CTU3** - GetEmprestimoByIdAsync_DeveRetornarOsDadosDoEmprestimo_QuandoOIdInformadoForValido<br>
**CTU4** - GetEmprestimoByIdAsync_NaoDeveRetornarOsDadosDoEmprestimo_QuandoOIdInformadoForInvalido<br>
**CTU5** - CreateEmprestimo_DeveRealizarAInclusaoDoEmprestimo_QuandoOsDadosForemValidos<br>
**CTU6** - CreateEmprestimo_NaoDeveRealizarAInclusaoDoEmprestimo_QuandoOsDadosForemInvalidos<br>
**CTU7** - DeleteEmprestimo_DeveRealizarAExclusaoDoEmprestimo_QuandoOEmprestimoExistir<br>
**CTU8** - DeleteEmprestimo_NaoDeveRealizarAExclusaoDoEmprestimo_QuandoOEmprestimoNaoExistir<br>

### PatrimonioServicesTests

**CTU1** - GetAllPatrimoniosAsync_DeveRetornarAListaDePatrimoniosCadastrados_QuandoExistirPatrimoniosCadastrados<br>
**CTU2** - GetAllPatrimoniosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirPatrimoniosCadastrados<br>
**CTU3** - GetPatrimonioByIdAsync_DeveRetornarOsDadosDoPatrimonio_QuandoOIdInformadoForValido<br>
**CTU4** - GetPatrimonioByIdAsync_NaoDeveRetornarOsDadosDoPatrimonio_QuandoOIdInformadoForInvalido<br>
**CTU5** - CreatePatrimonio_DeveRealizarAInclusaoDoPatrimonio_QuandoOsDadosForemValidos<br>
**CTU6** - CreatePatrimonio_NaoDeveRealizarAInclusaoDoPatrimonio_QuandoOsDadosForemInvalidos<br>
**CTU7** - DeletePatrimonio_DeveRealizarAExclusaoDoPatrimonio_QuandoOPatrimonioExistir<br>
**CTU8** - DeletePatrimonio_NaoDeveRealizarAExclusaoDoPatrimonio_QuandoOPatrimonioNaoExistir<br>

## [Backend] - Testes funcionais de API (manuais)

## Acervos

**CTF1: GET api/Acervos - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado <br>
**When** a rota GET api/Acervos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter um array de objetos para cada acervo cadastrado no banco de dados <br>

**CTF2: POST api/Acervos - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades obrigatórias sejam informados no request body <br>
**When** a rota POST api/Acervos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo cadastrado conforme as informações enviadas na requisição <br>
**And** o acervo cadastrado deve ser inserido no banco de dados <br>

**CTF3: GET api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente)**

**Given** um acervoId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo informado como parâmetro <br>

**CTF4: PUT api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente) e todos os dados obrigatórios**

**Given** um acervoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo alterado <br>
**And** os dados do acervo devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**CTF5: DELETE api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente)**

**Given** um acervoId válido (existente) seja informado como parâmetro <br>
**When** a rota DELETE api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o acervo deve ser excluído no banco de dados <br>

## Empréstimos

**CTF6: GET api/Emprestimos - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado <br>
**When** a rota GET api/Emprestimos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter um array de objetos para cada empréstimo cadastrado no banco de dados <br>

**CTF7: POST api/Emprestimos - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades obrigatórias sejam informados no request body <br>
**When** a rota POST api/Emprestimos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do empréstimo cadastrado conforme as informações enviadas na requisição <br>
**And** o empréstimo cadastrado deve ser inserido no banco de dados <br>

**CTF8: GET api/Emprestimos/{emprestimoId} - Executando a rota informando um emprestimoId válido (existente)**

**Given** um emprestimoId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do empréstimo informado como parâmetro <br>

**CTF9: PUT api/Emprestimos/{emprestimoId} - Executando a rota informando um emprestimoId válido (existente) e todos os dados obrigatórios**

**Given** um emprestimoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do empréstimo alterado <br>
**And** os dados do empréstimo devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**CTF10: DELETE api/Emprestimos/{emprestimoId} - Executando a rota informando um emprestimoId válido (existente)**

**Given** um emprestimoId válido (existente) seja informado como parâmetro <br>
**When** a rota DELETE api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o empréstimo deve ser excluído no banco de dados <br>

## Patrimônios

**CT11: GET api/Patrimonios - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado <br>
**When** a rota GET api/Patrimonios for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter um array de objetos para cada patrimônio cadastrado no banco de dados <br>

**CTF12: POST api/Patrimonios - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades obrigatórias sejam informados no request body <br>
**When** a rota POST api/Patrimonios for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimônio cadastrado conforme as informações enviadas na requisição <br>
**And** o patrimônio cadastrado deve ser inserido no banco de dados <br>

**CTF13: GET api/Patrimonios/{patrimonioId} - Executando a rota informando um patrimonioId válido (existente)**

**Given** um patrimonioId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Patrimonios/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimônio informado como parâmetro <br>

**CTF14: PUT api/Patrimonios/{patrimonioId} - Executando a rota informando um patrimonioId válido (existente) e todos os dados obrigatórios**

**Given** um patrimonioId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Patrimonios/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimônio alterado <br>
**And** os dados do patrimônio devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**CTF15: DELETE api/Patrimonios/{patrimonioId} - Executando a rota informando um patrimonioId válido (existente)**

**Given** um patrimonioId válido (existente) seja informado como parâmetro <br>
**When** a rota DELETE api/Patrimonios/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o patrimônio deve ser excluído no banco de dados <br>

## Usuarios

**CTF16: GET api/Usuarios - Executando a rota sem informar nenhum parâmetro**

**Given** que nenhum parâmetro seja informado<br>
**When** a rota GET api/Usuarios for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter um array de objetos para cada usuario cadastrado no banco de dados<br>

**CTF17: POST api/Usuarios - Realizando a requisição informando os dados obrigatórios corretamente**

**Given** que as propriedades obrigatórias sejam informados no request body<br>
**When** a rota POST api/Usuarios for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do usuario cadastrado conforme as informações enviadas na requisição<br>
**And** o usuario cadastrado deve ser inserido no banco de dados<br>

**CTF18: GET api/Usuarios/{usuarioId} - Executando a rota informando um usuarioId válido (existente)**

**Given** um usuarioId válido (existente) seja informado como parâmetro<br>
**When** a rota GET api/Usuarios/{usuarioId} for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do usuario informado como parâmetro<br>

**CTF19: GET api/Usuarios/{nome}/nome - Executando a rota informando um nome válido (existente)**

**Given** um nome válido (existente) seja informado como parâmetro<br>
**When** a rota GET api/Usuarios/{nome}/nome for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do nome informado como parâmetro<br>

**CTF20: PUT api/Usuarios/{usuarioId} - Executando a rota informando um usuarioId válido (existente) e todos os dados obrigatórios**

**Given** um usuarioId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos<br>
**When** a rota PUT api/Usuarios/{usuarioId} for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do usuario alterado<br>
**And** os dados do usuario devem ser atualizados no banco de dados conforme os dados enviados na requisição<br>

**CTF21: DELETE api/Usuarios/{usuarioId} - Executando a rota informando um usuarioId válido (existente)**

**Given** um usuarioId válido (existente) seja informado como parâmetro<br>
**When** a rota DELETE api/Usuarios/{usuarioId} for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o usuario deve ser excluído no banco de dados<br>

## [Frontend] - Testes de Sistema

## Usuários

**CTS1: Usuário - Cadastrando um usuário com sucesso**

**Given** as informações obrigatórios sejam informadas no formulário de cadastro <br>
**When** o botão Cadastre-se for acionado <br>
**Then** o usuário deve ser registrado <br>
**And** o usuário deve ser direcionado para a tela principal do site <br>

**CTS2: Usuário - Tentando cadastrar um usuário sem informar todos os dados obrigatórios**

**Given** alguma informação obrigatória não seja informada no formulário de cadastro <br>
**When** o botão Cadastre-se for acionado <br>
**Then** o usuário não deve ser registrado <br>
**And** uma mensagem de erro deve ser apresentada <br>

**CTS3: Usuário - Realizando o login com sucesso**

**Given** as informações de um usuário cadastrado sejam informadas corretamente no formulário de login <br>
**When** o botão Login for acionado <br>
**Then** o usuário deve ser direcionado para a tela principal do site <br>

**CTS4: Usuário - Tentando realizar o login para um usuário não cadastrado**

**Given** as informações de um usuário não cadastrado sejam informadas no formulário de login <br>
**When** o botão Login for acionado <br>
**Then** uma mensagem de erro deve ser apresentada <br>

## Detalhes do Acervo

**CTS1: Tela sendo populada com os livros cadastrados no Banco de Dados**

**Given** o usuário esteja na tela principal do site <br>
**When** o botão de Detalhes for acionado nos resultados de pesquisa <br>
**Then** as informações do livro selecionado devem ser apresentadas conforme o registro existente no banco de dados <br>

# Evidências de Testes de Software

## [Backend] - Testes de unidade (automatizados)

### Resultado da execução:

<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/ResultadoExecucao.png>
</p>
</br>

## [Backend] - Testes funcionais de API (manuais)

## Acervos

**CTF1: GET api/Acervos - Executando a rota sem informar nenhum parâmetro**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que nenhum parâmetro seja informado <br>
**When** a rota GET api/Acervos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter um array de objetos para cada acervo cadastrado no banco de dados <br>

**Evidências:**

Executando a rota sem informar nenhum parâmetro:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/GETAcervo1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/GETAcervo2.png>
</p>
</br>

**CTF2: POST api/Acervos - Realizando a requisição informando os dados obrigatórios corretamente**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que as propriedades obrigatórias sejam informados no request body <br>
**When** a rota POST api/Acervos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo cadastrado conforme as informações enviadas na requisição <br>
**And** o acervo cadastrado deve ser inserido no banco de dados <br>

**Evidências:**

Executando a rota informando os dados obrigatórios:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/POSTAcervo1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/POSTAcervo2.png>
</p>
</br>

Acervo inserido no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/POSTAcervo3.png>
</p>
</br>

**CTF3: GET api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um acervoId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo informado como parâmetro <br>

**Evidências:**

Executando a rota informando um Id válido (existente) como parâmetro:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/GETIdAcervo1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/GETIdAcervo2.png>
</p>
</br>

**CTF4: PUT api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente) e todos os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um acervoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo alterado <br>
**And** os dados do acervo devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**Evidências:**

Dados do acervo 3 no banco de dados antes da alteração:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/PUTAcervo1.png>
</p>
</br>

Executando a rota para atualizar a edição e o ano de publicação:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/PUTAcervo2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/PUTAcervo3.png>
</p>
</br>

Dados do acervo atualizados no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/PUTAcervo4.png>
</p>
</br>

**CTF5: DELETE api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um acervoId válido (existente) seja informado como parâmetro <br>
**When** a rota DELETE api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o acervo deve ser excluído no banco de dados <br>

**Evidências:**

Dados do acervo 2 no banco de dados antes da exclusão:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/DELETEAcervo1.png>
</p>
</br>

Executando a rota para excluir o acervo:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/DELETEAcervo2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/DELETEAcervo3.png>
</p>
</br>

Acervo excluído no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/DELETEAcervo4.png>
</p>
</br>

## Empréstimos 

**CTF6: GET api/Emprestimo - Executando a rota sem informar nenhum parâmetro**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que nenhum parâmetro seja informado <br>
**When** a rota GET api/Emprestimo for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter um array de objetos para cada emprestimo cadastrado no banco de dados <br>

**Evidências:**

Executando a rota sem informar nenhum parâmetro:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/GETEmprestimos1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/GETEmprestimos2.png>
</p>
</br>

**CTF7: POST api/Emprestimos - Realizando a requisição informando os dados obrigatórios corretamente**</br>

**Status do caso de teste:** Aprovado

**BDD**:</br></br>

**Given** que as propriedades obrigatórias sejam informados no request body <br>
**When** a rota POST api/Emprestimos for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do emprestimo cadastrado conforme as informações enviadas na requisição <br>
**And** o emprestimo cadastrado deve ser inserido no banco de dados <br>

Evidências:
Executando a rota informando os dados obrigatórios:
</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTEmprestimos1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTEmprestimos2.png>
</p>
</br>

Emprestimo inserido no banco de dados:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTEmprestimos3.png>
</p>
</br>

**CTF8: GET api/Emprestimos/{emprestimoId} - Executando a rota informando um emprestimoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um emprestimoId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do emprestimo informado como parâmetro <br>

**Evidências:**

Executando a rota informando um Id válido (existente) como parâmetro:
</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/GETIDEmprestimos1.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/GETIDEmprestimos1.png>
</p>
</br>

**CTF9: PUT api/Emprestimos/{emprestimoId} - Executando a rota informando um emprestimoId válido (existente) e todos os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um emprestimoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do emprestimo alterado <br>
**And** os dados do emprestimo devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**Evidências:**

Dados do emprestimo 3 no banco de dados antes da alteração:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTEmprestimos1.png>
</p>
</br>

Executando a rota para atualizar a edição username:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTEmprestimos2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTEmprestimos3.png>
</p>
</br>

Dados do emprestimo atualizados no banco de dados:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTEmprestimos4.png>
</p>
</br>

**CTF10: DELETE api/Emprestimos/{emprestimoId} - Executando a rota informando um emprestimoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um emprestimoId válido (existente) seja informado como parâmetro
**When** a rota DELETE api/Emprestimos/{emprestimoId} for executada
**Then** o status code 200 deve ser retornado
**And** o empréstimo deve ser excluído no banco de dados

**Evidências:**

Dados do empréstimo 1 no banco de dados antes da exclusão:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELEmprestimos1.png>
</p>
</br>

Executando a rota para excluir o empréstimo:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELEmprestimos2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELEmprestimos3.png>
</p>
</br>

Emprestimo excluído no banco de dados:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELEmprestimos5.png>
</p>

## Patrimônio

**CTF11: GET api/Patrimonios- Executando a rota sem informar nenhum parâmetro**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que nenhum parâmetro seja informado <br>
**When** a rota GET api/Patrimonios for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter um array de objetos para cada patrimonio cadastrado no banco de dados <br>

**Evidências:**

Executando a rota sem informar nenhum parâmetro:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTPatrimonios1.png>
</p>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTPatrimonios2.png>
</p>

**CTF12: POST api/Patrimonios - Realizando a requisição informando os dados obrigatórios corretamente**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** que as propriedades obrigatórias sejam informados no request body <br>
**When** a rota POST api/Patrimonios for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimonio cadastrado conforme as informações enviadas na requisição <br>
**And** o patrimonio cadastrado deve ser inserido no banco de dados <br>

**Evidências:**

Executando a rota informando os dados obrigatórios:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTPatrimonios1.png>
</p>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTPatrimonios2.png>
</p>

 Patrimonio inserido no banco de dados:

 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/POSTPatrimonio3.png>
</p>
</br>

**CTF13: GET api/Patrimonio/{patrimonioId} - Executando a rota informando um patrimonioId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um patrimonioId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Patrimonio/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimonio informado como parâmetro <br>

**Evidências:**

Executando a rota informando um Id válido (existente) como parâmetro:

 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/GETIDPatrimonios1.png>
</p>
</br>

Resposta da requisição:

 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/GETIDPatrimonios2.png>
</p>
</br>

**CTF14: PUT api/Patrimonio/{patrimonioId} - Executando a rota informando um funcionarioId válido (existente) e todos os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um patrimonioId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Patrimonio/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimonio alterado <br>
**And** os dados do patrimonio devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**Evidências:**

Dados do patrimonio 1 no banco de dados antes da alteração:


 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTPatrimonio1.png>
</p>
</br>

Executando a rota para atualizar a edição do campo prateleira:

 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTPatrimonio2.png>
</p>
</br>


Resposta da requisição:

 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTPatrimonio3.png>
</p>
</br>

Dados do patrimonio atualizados no banco de dados:

 </br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/PUTPatrimonio4.png>
</p>
</br>

**CTF15: DELETE api/Patrimonios/{patrimonioId} - Executando a rota informando um acervoId válido (existente)**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** um patrimonioId válido (existente) seja informado como parâmetro <br>
**When** a rota DELETE api/Patrimonios/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o patrimonio deve ser excluído no banco de dados <br>

**Evidências:**

Dados do patrimonio 3 no banco de dados antes da exclusão:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELPatrimonio1.png>
</p>
</br>

Executando a rota para excluir o patrimonio:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELPatrimonio2.png>
</p>
</br>

Resposta da requisição:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELPatrimonio3.png>
</p>
</br>

Patrimônio excluído no banco de dados:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/DELPatrimonio4.png>
</p>
</br>

## Usuarios

**CTF16: GET api/Usuarios - Executando a rota sem informar nenhum parâmetro**<br>

**Status do caso de teste:** Aprovado<br>

**BDD:**<br/><br/>
**Given** que nenhum parâmetro seja informado<br>
**When** a rota GET api/Usuarios for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter um array de objetos para cada usuario cadastrado no banco de dados<br>

**Evidências:** </br>

![GetAll](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/83f5f191-1011-41fc-b6fe-9c3808398a9d)

</br>

**CTF17: POST api/Usuarios - Realizando a requisição informando os dados obrigatórios corretamente**<br>

**Status do caso de teste:** Aprovado<br>

**BDD:**<br/><br/>
**Given** que as propriedades obrigatórias sejam informados no request body<br>
**When** a rota POST api/Usuarios for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do usuario cadastrado conforme as informações enviadas na requisição<br>
**And** o usuario cadastrado deve ser inserido no banco de dados<br>

**Evidências:** </br> 

![Post1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/50190fa1-26bf-4f71-ad20-a6369ff88b6b)
![Post2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/5fceb7d1-10c1-416e-9004-89618178eec4)

</br>

**CTF18: GET api/Usuarios/{usuarioId} - Executando a rota informando um usuarioId válido (existente)**<br>

**Status do caso de teste:** Aprovado<br>

**BDD:**<br/><br/>
**Given** um usuarioId válido (existente) seja informado como parâmetro<br>
**When** a rota GET api/Usuarios/{usuarioId} for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do usuario informado como parâmetro<br>

**Evidências:** </br>

![GetId](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/a2102b36-c0ac-41b7-89af-99779161a4e8)

</br>

**CTF19: GET api/Usuarios/{nome}/nome - Executando a rota informando um nome válido (existente)**<br>

**Status do caso de teste:** Aprovado<br>

**BDD:**<br/><br/>
**Given** um nome válido (existente) seja informado como parâmetro<br>
**When** a rota GET api/Usuarios/{nome}/nome for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do nome informado como parâmetro<br>

**Evidências:** </br>

![GetNome](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/740fcdba-a622-4f1e-bbc7-07278ba1ecbc)

</br>

**CTF20: PUT api/Usuarios/{usuarioId} - Executando a rota informando um usuarioId válido (existente) e todos os dados obrigatórios**<br>

**Status do caso de teste:** Aprovado<br>

**BDD:**<br/><br/>
**Given** um usuarioId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos<br>
**When** a rota PUT api/Usuarios/{usuarioId} for executada<br>
**Then** o status code 200 deve ser retornado<br>
**And** o response body deve conter os dados do usuario alterado<br>
**And** os dados do usuario devem ser atualizados no banco de dados conforme os dados enviados na requisição<br>

**Evidências:** </br>

![Put1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/d494b5e3-d81c-4738-8ba8-c816868e78f4)
![Put2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/5e800531-b846-4253-896d-8aa8c39f7d50)
![Put3](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/70c2f96e-ce23-42c0-887a-971385249f1e)

</br>

**CTF21: DELETE api/Usuarios/{usuarioId} - Executando a rota informando um usuarioId válido (existente)**<br>

**Given** um usuarioId válido (existente) seja informado como parâmetro <br>
**When** a rota DELETE api/Usuarios/{usuarioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o usuario deve ser excluído no banco de dados<br>

**Evidências:** </br>

![Delete1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/cfed5058-cc44-48c5-a6a4-666a0c63753b)
![Delete2](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/assets/124921806/2b244661-21cc-4631-aa88-42658fc9efe4)

</br>

## [Frontend] - Testes de Sistema

## Usuários

**CTS1: Usuário - Cadastrando um usuário com sucesso**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** as informações obrigatórios sejam informadas no formulário de cadastro <br>
**When** o botão Cadastre-se for acionado <br>
**Then** o usuário deve ser registrado <br>
**And** o usuário deve ser direcionado para a tela principal do site <br>

**Evidências:**

Preenchendo as informações obrigatórias no formulário e clicando no botão Cadastre-se:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaCadastroUsuario1.png>
</p>
</br>

Usuário direcionado para a tela principal:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaCadastroUsuario2.png>
</p>
</br>

Usuário registrado no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaCadastroUsuario3.png>
</p>
</br>

**CTS2: Usuário - Tentando cadastrar um usuário sem informar todos os dados obrigatórios**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** alguma informação obrigatória não seja informada no formulário de cadastro <br>
**When** o botão Cadastre-se for acionado <br>
**Then** o usuário não deve ser registrado <br>
**And** uma mensagem de erro deve ser apresentada <br>

**Evidências:**

Informação obrigatória não informada e botão Cadastre-se acionado:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaCadastroUsuario4.png>
</p>
</br>

**CTS3: Usuário - Realizando o login com sucesso**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** as informações de um usuário cadastrado sejam informadas corretamente no formulário de login <br>
**When** o botão Login for acionado <br>
**Then** o usuário deve ser direcionado para a tela principal do site <br>

**Evidências:**

Usuário 'RafaelaTeste' cadastrado no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaCadastroUsuario3.png>
</p>
</br>

Preenchendo as informações do usuário cadastrado no formulário de login:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaLogin1.png>
</p>
</br>

Usuário logado e direcionado para a tela principal:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaLogin2.png>
</p>
</br>

**CTS4: Usuário - Tentando realizar o login para um usuário não cadastrado**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** as informações de um usuário não cadastrado sejam informadas no formulário de login <br>
**When** o botão Login for acionado <br>
**Then** uma mensagem de erro deve ser apresentada <br>

**Evidências:**

Usuário 'RafaelaTeste1' não cadastrado no banco de dados:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaLogin3.png>
</p>
</br>

Botão Login acionado:

</br>
<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/TelaLogin4.png>
</p>
</br>

## Detalhes do Acervo

**CTS1: Tela sendo populada com os livros cadastrados no Banco de Dados**

**Status do caso de teste:** Aprovado

**BDD:**<br/><br/>
**Given** o usuário esteja na tela principal do site <br>
**When** o botão de Detalhes for acionado nos resultados de pesquisa <br>
**Then** as informações do livro selecionado devem ser apresentadas conforme o registro existente no banco de dados <br>

**Evidências:**

Usuário visualiza as infromações do livro:

</br>
<p align="center">
<img src=https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/blob/main/docs/img/Detalhes-evidencia.png>
</p>
</br>
