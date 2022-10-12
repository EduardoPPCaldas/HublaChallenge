import axios from "axios";
import { ChangeEvent, FormEvent, useState } from "react";
import { Button, Container, Form, FormControlProps, Toast, ToastContainer } from "react-bootstrap";
import { NavbarComponent } from "../../components/NavbarComponent";
import logo from "../../assets/logo.svg";

export function Upload(){
    const [show, setShow] = useState(false);
    const [success, setSuccess] = useState(false);
    const [message, setMessage] = useState("");
    const [background, setBackground] = useState("danger");
    const [file, setFile] = useState<File>();

    const handleFileChange = (event: any) => {
        // event has a type of ChangeEvent<HTMLInputElement>, the Form.Control event type it's not available but it can be mapped to ChangeEvent<HTMLInputElement> type
        const fileFormList = event.target.files;

        if(!fileFormList) return;

        setFile(fileFormList[0]);
    }

    const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        let formData = new FormData();
        if(!file) return;
        formData.append("file", file);

        axios.post("http://localhost:5015/api/sale", formData, { headers: {
            'Content-Type': 'multipart/form-data'
        }}).then(res => {
            if(res.data.success){
                setMessage("Sales saved with success!")
                setBackground("success");
                setSuccess(true)
                setShow(true)
                return;
            }

            setMessage(res.data.message);
            setBackground("danger")
            setSuccess(false)
            setShow(true)

        }).catch(err => {
            setMessage("Unexpected error");
            setBackground("danger")
            setSuccess(false)
            setShow(true)
        })
    }

    return (
        <>
            <NavbarComponent/>
            <ToastContainer className="p-3 pt-5" position="top-end">
                <Toast onClose={() => setShow(false)} show={show} delay={3000} autohide bg={background}>
                    <Toast.Header>
                        <img
                            src={logo}
                            alt="Hubla challenge logo"
                            width="30"
                            height="30"
                            className="d-inline-block align-top mx-2"
                        />
                        {success ? (<strong>Success!</strong>) : (<strong>Error</strong>)}
                    </Toast.Header>
                    <Toast.Body>{message}</Toast.Body>
                </Toast>
            </ToastContainer>
            <Container>
                <Form onSubmit={(event) => handleSubmit(event)} aria-label="form">
                    <Form.Group className="my-3">
                        <Form.Label >Send your sales file here:</Form.Label>
                        <Form.Control
                            name="file"
                            type="file"
                            onChange={(e) => handleFileChange(e)}
                        >
                        </Form.Control>
                    </Form.Group>
                    <Button variant="dark" type="submit">Submit</Button>
                </Form>
            </Container>
        </>
    )
}