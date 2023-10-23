import { type Emprestimo } from '../Emprestimos/Emprestimo'

export interface Usuario{
    nome: string
    localizacao: string
    password: string
    userName:string
    telefone:string
    Emprestimos: Emprestimo[]
}