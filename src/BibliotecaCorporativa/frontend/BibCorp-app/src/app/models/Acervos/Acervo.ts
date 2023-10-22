import { type Patrimonio } from '../Patrimonios/Patrimonio'

export interface Acervo {
  id: number
  patrimonioId: number
  iSBN: string
  titulo: string
  autor: string
  subTitulo: string
  resumo: string
  anoPublicacao: string
  editora: string
  edicao: string
  capaUrl: string
  qtdeDisponivel: number
  qtdeEmTransito: number
  qtdeEmprestada: number
  patrimonio: Patrimonio[]
}
