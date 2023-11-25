import { type Patrimonio } from '../../patrimonios/models/patrimonio/Patrimonio'
import { type Acervo } from '../Acervos/Acervo'

export class Emprestimo {
  id: number
  userName: string
  status: Status
  dataEmprestimo: string
  dataPrevistaDevolucao: string
  qtdeDiasEmprestimo: number
  dataDevolucao: string
  qtdeDiasAtraso: number
  acervoId: number
  acervo: Acervo
  patrimonioId: number
  patrimonio: Patrimonio
  localDeColeta: string
  localDeEntrega: string
}

export enum Status{
  Reservado = 1,
  Emprestado = 2,
  Devolvido = 3,
  Renovado = 4,
  Recusado = 5
}
