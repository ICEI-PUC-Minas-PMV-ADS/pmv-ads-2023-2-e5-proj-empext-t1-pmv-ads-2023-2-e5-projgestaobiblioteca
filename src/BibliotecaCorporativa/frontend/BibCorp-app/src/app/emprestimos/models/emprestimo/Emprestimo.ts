import { Acervo } from "src/app/acervos";
import { Patrimonio } from "src/app/patrimonios";

export class Emprestimo {
  id: number;
  userName: string;
  status: Status;
  dataEmprestimo: Date;
  dataPrevistaDevolucao: Date;
  qtdeDiasEmprestimo: number;
  dataDevolucao: Date;
  qtdeDiasAtraso: number;
  acervoId: number;
  acervo: Acervo;
  patrimonioId: number;
  patrimonio: Patrimonio;
  localDeColeta: string;
  localDeEntrega: string;
}

export enum Status {
  Reservado = 1,
  Emprestado = 2,
  Devolvido = 3,
  Renovado = 4,
  Recusado = 5,
}
