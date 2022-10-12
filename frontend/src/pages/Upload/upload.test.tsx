import { expect, it } from "vitest"
import { render, screen } from "@testing-library/react";
import { Upload } from ".";

it("should render form", () => {
    render(<Upload/>);
    const form = screen.getByRole('form');
    expect(form).toBeInTheDocument();
})