# Planos de Testes de Software

## [Backend] - Testes de unidade (automatizados)

Ferramenta de testes: xUnit.net (disponilizada para aplicações do .NET Framework)

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

### Acervos

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

**CTF4: PUT api/Acervos/{acervoId} - Executando a rota informando um funcionarioId válido (existente) e todos os dados obrigatórios**

**Given** um acervoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Acervos/{acervoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do acervo alterado <br>
**And** os dados do acervo devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**CTF5: DELETE api/Acervos/{acervoId} - Executando a rota informando um acervoId válido (existente)**

**Given** um acervoId válido (existente) seja informado como parâmetro
**When** a rota DELETE api/Acervos/{acervoId} for executada
**Then** o status code 200 deve ser retornado
**And** o acervo deve ser excluído no banco de dados

### Empréstimos

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

**CTF8: GET api/Emprestimos/{emprestimoId} - Executando a rota informando um acervoId válido (existente)**

**Given** um emprestimoId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do empréstimo informado como parâmetro <br>

**CTF9: PUT api/Emprestimos/{emprestimoId} - Executando a rota informando um funcionarioId válido (existente) e todos os dados obrigatórios**

**Given** um emprestimoId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Emprestimos/{emprestimoId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do empréstimo alterado <br>
**And** os dados do empréstimo devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**CTF10: DELETE api/Emprestimos/{emprestimoId} - Executando a rota informando um acervoId válido (existente)**

**Given** um emprestimoId válido (existente) seja informado como parâmetro
**When** a rota DELETE api/Emprestimos/{emprestimoId} for executada
**Then** o status code 200 deve ser retornado
**And** o empréstimo deve ser excluído no banco de dados

### Patrimônios

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

**CTF13: GET api/Patrimonios/{patrimonioId} - Executando a rota informando um acervoId válido (existente)**

**Given** um patrimonioId válido (existente) seja informado como parâmetro <br>
**When** a rota GET api/Patrimonios/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimônio informado como parâmetro <br>

**CTF14: PUT api/Patrimonios/{patrimonioId} - Executando a rota informando um funcionarioId válido (existente) e todos os dados obrigatórios**

**Given** um patrimonioId válido (existente) seja informado como parâmetro e que no request body todos os dados obrigatórios sejam preenchidos <br>
**When** a rota PUT api/Patrimonios/{patrimonioId} for executada <br>
**Then** o status code 200 deve ser retornado <br>
**And** o response body deve conter os dados do patrimônio alterado <br>
**And** os dados do patrimônio devem ser atualizados no banco de dados conforme os dados enviados na requisição <br>

**CTF15: DELETE api/Patrimonios/{patrimonioId} - Executando a rota informando um acervoId válido (existente)**

**Given** um patrimonioId válido (existente) seja informado como parâmetro
**When** a rota DELETE api/Patrimonios/{patrimonioId} for executada
**Then** o status code 200 deve ser retornado
**And** o patrimônio deve ser excluído no banco de dados
 
# Evidências de Testes de Software

## [Backend] - Testes de unidade automatizados

### Resultado da execução:

<p align="center">
<img src=https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e5-proj-empext-t1-pmv-ads-2023-2-e5-projgestaobiblioteca/main/docs/img/ResultadoExecucao.png>
</p>
</br>
