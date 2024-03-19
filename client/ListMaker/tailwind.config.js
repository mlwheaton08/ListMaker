/** @type {import('tailwindcss').Config} */
export default {
	content: [
		"./index.html",
		"./src/**/*.{js,ts,jsx,tsx}"
	],
	theme: {
		extend: {
			colors: {
				"clr-foreground": "var(--clr-foreground)",
				"clr-background": "var(--clr-background)",
				"clr-primary": "var(--clr-primary)",
				"clr-secondary": "var(--clr-secondary)",
				"clr-accent": "var(--clr-accent)",
				"clr-darker": "var(--clr-darker)",
			},
			height: {
				"nav-height": "var(--nav-height)",
				"screen-minus-nav-height": "var(--screen-minus-nav-height)"
			},
			margin: {
				"nav-height": "var(--nav-height)",
			},
		},
	},
	plugins: [],
}