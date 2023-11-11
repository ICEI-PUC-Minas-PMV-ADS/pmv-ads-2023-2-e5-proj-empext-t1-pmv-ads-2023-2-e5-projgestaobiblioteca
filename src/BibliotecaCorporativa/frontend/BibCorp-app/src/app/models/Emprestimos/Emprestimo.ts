import { type Patrimonio } from '../Patrimonios/Patrimonio'
import { type Acervo } from '../Acervos/Acervo'

export interface Emprestimo {
  Id: number
  UserName: string
  devolvido: boolean
  dataEmprestimo: string
  dataPrevistaDevolucao: string
  qtdeDiasEmprestimo: number
  dataDevolucao: string
  qtdeDiasAtraso: number
  acervoId: number
  acervos: Acervo[]
  patrimonioId: number
  patrimonios: Patrimonio[]
}
