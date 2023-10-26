import { type Emprestimo } from '../Emprestimos/Emprestimo'

export class Usuario{
    nome: string
    localizacao: string
    email: string
    password: string
    userName:string
    telefone:string
    Emprestimos: Emprestimo[]
    token: string
}