import { Emprestimo } from "./Emprestimo";

export interface Usuario {

  id: number;
  nome?: string;
  localizacao?: string;
  email?: string;
  senha?: string;
  emprestimos: Emprestimo[];

}
