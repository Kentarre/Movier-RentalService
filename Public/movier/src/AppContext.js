import React from 'react';

export const AppContext = React.createContext({
    selectedFilms: [],
    length: 0,
    getLength: () => {}
});