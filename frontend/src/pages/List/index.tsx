import { Table } from "react-bootstrap";
import { NavbarComponent } from "../../components/NavbarComponent";
import { getSales } from "../../services/sale-service";

export function List() {
    getSales();

    return (
        <>
            <NavbarComponent />
            <div className="container-lg mt-5">
                <Table striped bordered hover variant="dark">
                    <thead>
                        <tr>
                            <th>Type</th>
                            <th>Date</th>
                            <th>Product</th>
                            <th>Value</th>
                            <th>Salesman</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                            <td>@mdo</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
                            <td>@fat</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Larry the Bird</td>
                            <td>@twitter</td>
                            <td>@twitter</td>
                            <td>@twitter</td>
                        </tr>
                    </tbody>
                </Table>
            </div>
        </>
    )
}