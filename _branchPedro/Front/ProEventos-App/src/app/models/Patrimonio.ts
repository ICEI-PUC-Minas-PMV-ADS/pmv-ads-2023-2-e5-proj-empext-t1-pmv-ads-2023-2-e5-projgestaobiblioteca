import { Emprestimo } from "./Emprestimo";

export interface Patrimonio {

   id: number;
   local?: string;
   sala?: number;
   coluna?: number;
   prateleira?: number;
   posicao?: number;
   titulo?: string;
   isbn?: string;
   ativo: boolean;
   cadastro?: Date;
   ultimaAtualizacao?: Date;
   emprestimos?: Emprestimo[];

}
