import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";

export function NavbarComponent()
{
    return (
        <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="/">
            Hubla Challenge
          </Navbar.Brand>

          <Nav>
            <Nav.Link href="/">
                Sales list
            </Nav.Link>
            <Nav.Link href="/upload">
                Upload sales
            </Nav.Link>
          </Nav>
        </Container>
      </Navbar>
      );
}