import { type Patrimonio } from '../Patrimonios/Patrimonio'
import { type Acervo } from '../Acervos/Acervo'

export class Emprestimo {
  Id: number
  userName: string
  status: Status
  dataEmprestimo: string
  dataPrevistaDevolucao: string
  qtdeDiasEmprestimo: number
  dataDevolucao: string
  qtdeDiasAtraso: number
  acervoId: number
  acervos: Acervo[]
  patrimonioId: number
  patrimonios: Patrimonio[]
  localDeColeta: string
  localDeEntrega: string
}

export enum Status{
  Reservado = 1,
  Emprestado = 2,
  Devolvido = 3,
  Renovado = 4
}
