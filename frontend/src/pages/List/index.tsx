import axios from "axios";
import { useEffect, useState } from "react";
import { Table } from "react-bootstrap";
import { NavbarComponent } from "../../components/NavbarComponent";
import { SaleModel } from "../../models/sale-model";

export function List() {
    const [sales, getSales] = useState([{} as SaleModel])

    useEffect(() => {
        getSalesList();
    }, [])

    const getSalesList = () => {
        axios.get("http://localhost:5015/api/sale")
            .then(res => {
                const salesList = res.data.data;
                getSales(salesList);
            }).catch(err => {
                console.error(err);
            })
    }

    return (
        <>
            <NavbarComponent />
            <div className="container-lg mt-5">
                <Table striped bordered hover variant="dark">
                    <thead>
                        <tr>
                            <th>Type</th>
                            <th>Date</th>
                            <th>Product Description</th>
                            <th>Value</th>
                            <th>Salesman</th>
                        </tr>
                    </thead>
                    <tbody>
                        {sales.map((sale, i) => {
                            return (
                                <tr key={i}>
                                    <td>{sale.saleType}</td>
                                    <td>{new Date(sale.date).toLocaleDateString()}</td>
                                    <td>{sale.description}</td>
                                    <td>{Intl.NumberFormat('pt-br', {style: 'currency',
                                                                     currency: "BRL",
                                                                     maximumFractionDigits: 2}).format(sale.value)}</td>
                                    <td>{sale.salesmanName}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </Table>
            </div>
        </>
    )
}