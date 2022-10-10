import axios from "axios";
import { SaleModel } from "../models/sale-model";

type GetSalesResponse = {
    data: SaleModel[],
    errorCode: number,
    message: string | null,
    success: boolean
}

export async function getSales(): Promise<SaleModel[]>{
    const response = await axios.get<GetSalesResponse>("http://localhost:5015/api/sale");
    console.log(response.data.data);
    return response.data.data;
} 