import { expect, it } from "vitest";
import { render, screen } from "@testing-library/react"; 
import { List } from ".";

it('Should render table', () => {
    render(<List/>);
    const table = screen.getByRole('table');
    expect(table).toBeInTheDocument();
});
