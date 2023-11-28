import { Patrimonio } from "src/app/patrimonios";

export class Acervo {
  id: number;
  isbn: string;
  genero: string;
  titulo: string;
  autor: string;
  subTitulo: string;
  resumo: string;
  anoPublicacao: string;
  dataCriacao: string;
  editora: string;
  edicao: string;
  capaUrl: string;
  qtdPaginas: number;
  comentarios: string;
  qtdeDisponivel: number;
  qtdeEmTransito: number;
  qtdeEmprestada: number;
  patrimonios: Patrimonio[];
}
