export class GerenciamentoEmprestimo {
    acao: TipoAcaoEmprestimo
  }
  
  export enum TipoAcaoEmprestimo{
    Aprovar = 1,
    Recusar = 2,
    Devolver = 3
  }