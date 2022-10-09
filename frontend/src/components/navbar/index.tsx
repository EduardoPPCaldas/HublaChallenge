import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";

export function NavbarComponent()
{
    return (
        <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="#home">
            Hubla Challenge
          </Navbar.Brand>

          <Nav>
            <Nav.Link href="#List">
                Sales list
            </Nav.Link>
            <Nav.Link href="#Upload">
                Upload sales
            </Nav.Link>
          </Nav>
        </Container>
      </Navbar>
      );
}