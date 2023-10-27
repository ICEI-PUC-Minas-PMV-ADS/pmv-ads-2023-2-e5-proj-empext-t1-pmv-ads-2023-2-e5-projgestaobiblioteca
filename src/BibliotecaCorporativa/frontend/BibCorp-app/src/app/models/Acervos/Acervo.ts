import { type Patrimonio } from '../Patrimonios/Patrimonio'

export interface Acervo {
  id: number
  patrimonioId: number
  iSBN: string
  titulo: string
  autor: string
  subTitulo: string
  genero: string
  resumo: string
  anoPublicacao: string
  dataCriacao: String
  editora: string
  edicao: string
  capaUrl: string
  qtdPaginas: number
  comentarios: string
  qtdeDisponivel: number
  qtdeEmTransito: number
  qtdeEmprestada: number
  patrimonios: Patrimonio[]
}
