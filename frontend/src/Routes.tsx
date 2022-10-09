import { BrowserRouter, Route } from "react-router-dom";
import { List } from "./pages/List";
import { Upload } from "./pages/Upload";

export function Routes(){
    return (
        <BrowserRouter>
            <Route path="/">
                <List/>
            </Route>
            <Route path="/upload">
                <Upload/>
            </Route>
        </BrowserRouter>
    )
} 