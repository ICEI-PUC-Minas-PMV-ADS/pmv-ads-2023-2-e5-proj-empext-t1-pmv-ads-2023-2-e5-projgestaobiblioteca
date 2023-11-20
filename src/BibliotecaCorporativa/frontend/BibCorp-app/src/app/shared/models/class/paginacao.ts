export class Paginacao {
  paginaCorrente!: number
  totalDePaginas!: number
  itensPorPagina!: number
  totalDeItens!: number
}

export class ResultadoPaginado<T> {
  resultado!: T
  paginacao!: Paginacao
}
