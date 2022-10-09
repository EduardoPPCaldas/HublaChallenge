import { BrowserRouter, Route, Routes } from "react-router-dom";
import { List } from "./pages/List";
import { Upload } from "./pages/Upload";

export function AppRoutes(){
    return (
        <BrowserRouter>
            <Routes>               
                <Route path="/" element={<List/>} />
                <Route path="/upload" element={<Upload/>}/>
            </Routes>
        </BrowserRouter>
    )
} 