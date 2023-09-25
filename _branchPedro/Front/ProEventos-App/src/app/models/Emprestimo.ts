import { Patrimonio } from "./Patrimonio";
import { Usuario } from "./Usuario";

export interface Emprestimo {

  id: number;
  usuarioId?: number
  usuario?: Usuario[];
  // int? acervoId:
  // Acervo? acervo:
  patrimonioId?: number;
  patrimonio?: Patrimonio[];
  devolvido: boolean;
  dataEmprestimo?: Date;
  dataDevolucao?: Date;
  diasAtraso?: number;
  diasAlocacao?: number;

}
