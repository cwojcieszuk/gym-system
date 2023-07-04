/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './projects/spa/src/**/*.{html,js}'
  ],
  theme: {
    extend: {
      borderRadius: {
        base: '7px',
        big: '15px',
      },
      boxShadow: {
        e3: '0px 3px 3px -2px rgb(0 0 0 / 20%), 0px 3px 4px 0px rgb(0 0 0 / 14%), 0px 1px 8px 0px rgb(0 0 0 / 12%)',
        input: '0 1px 6px 0 rgb(0 0 0 / 15%)',
        base: '#d8d8d8 0px 3px 8px',
      },
      colors: {
        primary: '#660033',
        background: '#f8faff',
        purple: "#9B5995",
        form: {
          input: {
            black: 'rgba(0, 0, 0, 0.87)',
            gray: '#D3D3D3',
            red: '#f44336',
            green: '#006A4D',
          },
        },
      },
    },
  },
  plugins: [],
}
