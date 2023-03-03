export interface TransactionDTO{
    id: number,
    type: string,
    price : number,
    source : string,
    destination : string 
}

export interface landingPageDTO {
    NormalTransactions? : TransactionDTO[],
    BlockchainTransactions?: TransactionDTO[]
}